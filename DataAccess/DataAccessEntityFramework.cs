using CinemaApplication.Interfaces;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using Microsoft.EntityFrameworkCore;
using static CinemaApplication.Models.OrderConfirmationModel;

namespace CinemaApplication.DataAccess
{
    public class DataAccessEntityFramework : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccessEntityFramework(string entityFrameworkConnectionString)
        {
            if (string.IsNullOrWhiteSpace(entityFrameworkConnectionString))
            {
                throw new ArgumentNullException(nameof(entityFrameworkConnectionString), "Connection string is required for Entity Framework.");
            }
            _connectionString = entityFrameworkConnectionString;
        }

        private AppDbContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new AppDbContext(optionsBuilder.Options);
        }

        public bool RegisterUser(UserModel user)
        {
            AppUtils.WriteLine($"[EF Core] Attempting to register user: {user.Username}");
            try
            {
                using (var context = CreateContext())
                {
                    context.Users.Add(user);
                    int affectedRows = context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        AppUtils.WriteLine($"[EF Core] User '{user.Username}' registered successfully with ID: {user.UserId}.");
                        return true;
                    }
                    AppUtils.WriteLine($"[EF Core] Failed to register user '{user.Username}'. No rows affected.");
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                AppUtils.WriteLine($"[EF Core] DbUpdateException registering user '{user.Username}': {ex.Message}");
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    AppUtils.WriteLine($"[EF Core] Inner Exception: {innerException.Message}");
                    if (innerException is Microsoft.Data.SqlClient.SqlException sqlEx && (sqlEx.Number == 2627 || sqlEx.Number == 2601))
                    {
                        AppUtils.WriteLine($"[EF Core] Username or Email already exists.");
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[EF Core] General Error registering user '{user.Username}': {ex.Message}");
                return false;
            }
        }
        public UserModel AuthenticateUser(string username, string plainTextPassword)
        {
            UserModel user = null;
            try
            {
                using (var context = CreateContext())
                {
                    var foundUser = context.Users.FirstOrDefault(u => u.Username == username);
                    if (foundUser != null)
                    {
                        if (plainTextPassword == foundUser.Password)
                        {
                            user = foundUser;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[DataAccessEntityFramework] Error authenticating user '{username}': {ex.Message}");
            }
            return user;
        }
        public List<MovieModel> GetMoviesByStatus(string status)
        {
            List<MovieModel> movies = new List<MovieModel>();
            AppUtils.WriteLine($"[EF Core] Attempting to get movies with status: {status}");
            try
            {
                using (var context = CreateContext())
                {
                    movies = context.Movies
                                    .Where(m => m.Status == status)
                                    .OrderByDescending(m => m.ReleaseDate)
                                    .ToList();
                }
                AppUtils.WriteLine($"[EF Core] Found {movies.Count} movies with status: {status}");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[EF Core] General Error getting movies by status '{status}'");
            }
            return movies;
        }

        public List<SeatTypeModel> GetAllSeatTypes()
        {
            AppUtils.WriteLine("[EF Core] Getting all seat types.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.SeatTypes.OrderBy(st => st.TypeName).ToList();
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[EF Core] Error getting all seat types");
                return new List<SeatTypeModel>();
            }
        }

        public int AddCinemaRoom(CinemaRoomModel room)
        {
            AppUtils.WriteLine($"[EF Core] Adding new cinema room: {room.RoomName}");
            try
            {
                using (var context = CreateContext())
                {
                    if (room.CreatedAt == DateTime.MinValue) room.CreatedAt = DateTime.Now;
                    if (room.UpdatedAt == DateTime.MinValue) room.UpdatedAt = DateTime.Now;
                    if (string.IsNullOrEmpty(room.Status)) room.Status = "active";


                    context.CinemaRooms.Add(room);
                    context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Cinema room '{room.RoomName}' added successfully with ID: {room.RoomId}.");
                    return room.RoomId;
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[EF Core] Error adding cinema room '{room.RoomName}'");
                return -1;
            }
        }

        public List<CinemaRoomStatsModel> GetAllCinemaRoomsWithStats()
        {
            AppUtils.WriteLine("[EF Core] Getting all cinema rooms with stats.");
            List<CinemaRoomStatsModel> roomStatsList = new List<CinemaRoomStatsModel>();
            int sttCounter = 1;
            try
            {
                using (var context = CreateContext())
                {
                    var rooms = context.CinemaRooms
                                     .Include(cr => cr.Seats) // Include Seats collection
                                        .ThenInclude(s => s.SeatType)
                                     .OrderBy(cr => cr.RoomName)
                                     .ToList();

                    foreach (var cr in rooms)
                    {
                        roomStatsList.Add(new CinemaRoomStatsModel
                        {
                            STT = sttCounter++,
                            RoomId = cr.RoomId,
                            RoomName = cr.RoomName,
                            Status = cr.Status,
                            CreatedAt = cr.CreatedAt,
                            TotalSeats = cr.Seats.Count,
                            StandardSeats = cr.Seats.Count(s => s.SeatType != null && s.SeatType.TypeName == "Standard"),
                            VipSeats = cr.Seats.Count(s => s.SeatType != null && s.SeatType.TypeName == "VIP"),
                            CoupleSeats = cr.Seats.Count(s => s.SeatType != null && s.SeatType.TypeName == "Couple")
                        });
                    }
                }
                AppUtils.WriteLine($"[EF Core] Found {roomStatsList.Count} cinema rooms with stats.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[EF Core] Error getting all cinema rooms with stats");
            }
            return roomStatsList;
        }
        public bool AddSeats(List<SeatModel> seats)
        {
            if (seats == null || !seats.Any()) return true;

            AppUtils.WriteLine($"[EF Core] Attempting to add {seats.Count} seats.");
            try
            {
                using (var context = CreateContext())
                {
                    context.Seats.AddRange(seats);
                    context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Successfully added {seats.Count} seats.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[EF Core] Error adding seats");
                return false;
            }
        }
        public List<MovieModel> GetAllMovies()
        {
            AppUtils.WriteLine("[EF Core] Getting all movies.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Movies
                                  .OrderByDescending(m => m.ReleaseDate)
                                  .ThenBy(m => m.Title)
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine("[EF Core] Error getting all movies"); return new List<MovieModel>(); }
        }

        public int AddMovie(MovieModel movie)
        {
            AppUtils.WriteLine($"[EF Core] Adding new movie: {movie.Title}");
            try
            {
                using (var context = CreateContext())
                {
                    if (movie.CreatedAt == DateTime.MinValue) movie.CreatedAt = DateTime.UtcNow;
                    if (movie.UpdatedAt == DateTime.MinValue) movie.UpdatedAt = DateTime.UtcNow;

                    context.Movies.Add(movie);
                    context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Movie '{movie.Title}' added successfully with ID: {movie.MovieId}.");
                    return movie.MovieId; // MovieId được cập nhật sau SaveChanges nếu là Identity
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"[EF Core] Error adding movie '{movie.Title}'"); return 0; }
        }

        public bool UpdateMovie(MovieModel movie)
        {
            AppUtils.WriteLine($"[EF Core] Updating movie ID: {movie.MovieId} - {movie.Title}");
            try
            {
                using (var context = CreateContext())
                {
                    movie.UpdatedAt = DateTime.UtcNow;
                    context.Movies.Update(movie);
                    int affectedRows = context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Movie ID {movie.MovieId} update. Rows affected: {affectedRows}");
                    return affectedRows > 0;
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"[EF Core] Error updating movie ID {movie.MovieId}"); return false; }
        }

        public bool DeleteMovie(int movieId)
        {
            AppUtils.WriteLine($"[EF Core] Deleting movie ID: {movieId}");
            try
            {
                using (var context = CreateContext())
                {
                    var movieToDelete = context.Movies.Find(movieId);
                    if (movieToDelete != null)
                    {
                        context.Movies.Remove(movieToDelete);
                        int affectedRows = context.SaveChanges();
                        AppUtils.WriteLine($"[EF Core] Movie ID {movieId} delete. Rows affected: {affectedRows}");
                        return affectedRows > 0;
                    }
                    AppUtils.WriteLine($"[EF Core] Movie ID {movieId} not found for deletion.");
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                AppUtils.WriteLine($"[EF Core] DbUpdateException deleting movie ID {movieId}. It might be in use.");
                MessageBox.Show($"Không thể xóa phim này vì có thể đang được sử dụng trong các suất chiếu hoặc dữ liệu khác.\nChi tiết: {ex.InnerException?.Message ?? ex.Message}", "Lỗi Xóa Phim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex) { AppUtils.WriteLine($"[EF Core] Error deleting movie ID {movieId}"); return false; }
        }

        public MovieModel GetMovieById(int movieId)
        {
            AppUtils.WriteLine($"[EF Core] Attempting to get movie by ID: {movieId}");
            MovieModel movie = null;
            try
            {
                using (var context = CreateContext())
                {
                    movie = context.Movies.FirstOrDefault(m => m.MovieId == movieId);
                }

                if (movie != null)
                {
                    AppUtils.WriteLine($"[EF Core] Found movie: {movie.Title}");
                }
                else
                {
                    AppUtils.WriteLine($"[EF Core] Movie with ID {movieId} not found.");
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[EF Core] Error getting movie by ID {movieId}");
            }
            return movie;
        }
        public List<FoodItemModel> GetAllFoodItems()
        {
            AppUtils.WriteLine("[EF Core] Getting all food items.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.FoodItems
                                  .OrderBy(fi => fi.Category)
                                  .ThenBy(fi => fi.Name)
                                  .AsNoTracking()
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllFoodItems (EF): {ex.Message}\n{ex.StackTrace}"); return new List<FoodItemModel>(); }
        }
        public int AddFoodItem(FoodItemModel foodItem)
        {
            AppUtils.WriteLine($"[EF Core] Adding new food item: {foodItem.Name}");
            try
            {
                using (var context = CreateContext())
                {
                    if (foodItem.CreatedAt == DateTime.MinValue) foodItem.CreatedAt = DateTime.UtcNow;
                    if (foodItem.UpdatedAt == DateTime.MinValue) foodItem.UpdatedAt = DateTime.UtcNow;

                    context.FoodItems.Add(foodItem);
                    context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Food item '{foodItem.Name}' added successfully with ID: {foodItem.FoodItemId}.");
                    return foodItem.FoodItemId;
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in AddFoodItem (EF) for '{foodItem.Name}': {ex.Message}\n{ex.StackTrace}"); return 0; }
        }
        public bool UpdateFoodItem(FoodItemModel foodItem)
        {
            AppUtils.WriteLine($"[EF Core] Updating food item ID: {foodItem.FoodItemId} - {foodItem.Name}");
            try
            {
                using (var context = CreateContext())
                {
                    foodItem.UpdatedAt = DateTime.UtcNow;
                    context.FoodItems.Update(foodItem);
                    int rowsAffected = context.SaveChanges();
                    AppUtils.WriteLine($"[EF Core] Food item ID {foodItem.FoodItemId} update. Rows affected: {rowsAffected}");
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in UpdateFoodItem (EF) for ID {foodItem.FoodItemId}: {ex.Message}\n{ex.StackTrace}"); return false; }
        }
        public bool DeleteFoodItem(int foodItemId)
        {
            AppUtils.WriteLine($"[EF Core] Deleting food item ID: {foodItemId}");
            try
            {
                using (var context = CreateContext())
                {
                    var itemToDelete = context.FoodItems.Find(foodItemId);
                    if (itemToDelete != null)
                    {
                        context.FoodItems.Remove(itemToDelete);
                        int rowsAffected = context.SaveChanges();
                        AppUtils.WriteLine($"[EF Core] Food item ID {foodItemId} delete. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                    AppUtils.WriteLine($"[EF Core] Food item ID {foodItemId} not found for deletion.");
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                AppUtils.WriteLine($"ERROR: [EF Core] Error deleting food item ID {foodItemId} due to database constraints: {ex.Message}\n{ex.InnerException?.Message}");
                MessageBox.Show("Không thể xóa sản phẩm này vì đang được sử dụng trong các đơn hàng.", "Lỗi Xóa Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in DeleteFoodItem (EF) for ID {foodItemId}: {ex.Message}\n{ex.StackTrace}"); return false; }
        }
        public List<MovieModel> GetAllMoviesForScheduling()
        {
            AppUtils.WriteLine("[EF Core] Getting all movies for scheduling.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Movies
                                  .Where(m => m.Status == "active" || m.Status == "upcoming")
                                  .OrderBy(m => m.Title)
                                  .Select(m => new MovieModel { MovieId = m.MovieId, Title = m.Title, DurationMinutes = m.DurationMinutes, Status = m.Status }) // Chỉ lấy trường cần thiết
                                  .AsNoTracking()
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllMoviesForScheduling (EF Core): {ex.Message}"); return new List<MovieModel>(); }
        }
        public List<CinemaRoomModel> GetAllActiveCinemaRooms()
        {
            AppUtils.WriteLine("[EF Core] Getting all active cinema rooms.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.CinemaRooms
                                  .Where(r => r.Status == "active")
                                  .OrderBy(r => r.RoomName)
                                  .Select(r => new CinemaRoomModel { RoomId = r.RoomId, RoomName = r.RoomName }) // Chỉ lấy trường cần thiết
                                  .AsNoTracking()
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllActiveCinemaRooms (EF Core): {ex.Message}"); return new List<CinemaRoomModel>(); }
        }
        public List<ShowtimeModel> GetShowtimesForRoomOnDate(int roomId, DateTime date)
        {
            AppUtils.WriteLine($"[EF Core] Getting showtimes for Room ID: {roomId} on Date: {date:yyyy-MM-dd}");
            try
            {
                using (var context = CreateContext())
                {
                    DateTime startDate = date.Date; // 00:00:00 của ngày đó
                    DateTime endDate = date.Date.AddDays(1); // 00:00:00 của ngày kế tiếp

                    return context.Showtimes
                                  .Where(s => s.RoomId == roomId && s.StartTime >= startDate && s.StartTime < endDate)
                                  .OrderBy(s => s.StartTime)
                                  .AsNoTracking()
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimesForRoomOnDate (EF Core): {ex.Message}"); return new List<ShowtimeModel>(); }
        }
        public bool AddShowtime(ShowtimeModel showtime)
        {
            AppUtils.WriteLine($"[EF Core] Adding new showtime for Movie ID: {showtime.MovieId}, Room ID: {showtime.RoomId} at {showtime.StartTime}");
            try
            {
                using (var context = CreateContext())
                {
                    if (showtime.CreatedAt == DateTime.MinValue) showtime.CreatedAt = DateTime.UtcNow;
                    if (showtime.UpdatedAt == DateTime.MinValue) showtime.UpdatedAt = DateTime.UtcNow;

                    context.Showtimes.Add(showtime);
                    int affectedRows = context.SaveChanges();
                    return affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in AddShowtime (EF Core): {ex.Message}");
                return false;
            }
        }
        public List<FullShowtimeInfoModel> GetFullShowtimesByDate(DateTime date)
        {
            AppUtils.WriteLine($"[EF Core] Getting full showtimes for date: {date:yyyy-MM-dd}");
            List<FullShowtimeInfoModel> showtimes = new List<FullShowtimeInfoModel>();
            try
            {
                using (var context = CreateContext())
                {
                    DateTime startDate = date.Date;
                    DateTime endDate = date.Date.AddDays(1);

                    showtimes = context.Showtimes
                        .Where(s => s.StartTime >= startDate && s.StartTime < endDate)
                        .Include(s => s.Movie) // Navigation property
                        .Include(s => s.CinemaRoom) // Navigation property
                        .OrderBy(s => s.StartTime)
                        .ThenBy(s => s.CinemaRoom.RoomName)
                        .Select(s => new FullShowtimeInfoModel
                        {
                            ShowtimeId = s.ShowtimeId,
                            StartTime = s.StartTime,
                            EndTime = s.EndTime,
                            MovieId = s.MovieId,
                            MovieTitle = s.Movie.Title,
                            MovieDurationMinutes = s.Movie.DurationMinutes,
                            MoviePosterImageUrl = s.Movie.PosterImageUrl,
                            MovieGenre = s.Movie.Genre,
                            MovieRatingDetails = s.Movie.RatingDetails,
                            RoomId = s.RoomId,
                            RoomName = s.CinemaRoom.RoomName
                        })
                        .AsNoTracking()
                        .ToList();
                }
                AppUtils.WriteLine($"[EF Core] Found {showtimes.Count} showtimes for {date:yyyy-MM-dd}.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in GetFullShowtimesByDate (EF Core): {ex.Message}");
            }
            return showtimes;
        }
        public ShowtimeModel GetShowtimeById(int showtimeId)
        {
            AppUtils.WriteLine($"[EF Core] Getting showtime by ID: {showtimeId}");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Showtimes
                                  .Include(s => s.Movie)
                                  .Include(s => s.CinemaRoom)
                                  .AsNoTracking()
                                  .FirstOrDefault(s => s.ShowtimeId == showtimeId);
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimeById (EF Core): {ex.Message}"); return null; }
        }
        public List<ShowtimeBookingInfoModel> GetShowtimesForBooking(int movieId, DateTime date)
        {
            AppUtils.WriteLine($"[EF Core] Getting showtimes for booking for Movie ID: {movieId} on Date: {date:yyyy-MM-dd}");
            List<ShowtimeBookingInfoModel> showtimes = new List<ShowtimeBookingInfoModel>();
            try
            {
                using (var context = CreateContext())
                {
                    DateTime startDate = date.Date;
                    DateTime endDate = date.Date.AddDays(1);

                    showtimes = context.Showtimes
                        .Where(s => s.MovieId == movieId && s.StartTime >= startDate && s.StartTime < endDate && s.StartTime > DateTime.Now)
                        .Include(s => s.CinemaRoom) // Để lấy RoomName và RoomId
                            .ThenInclude(cr => cr.Seats) // Để tính TotalSeatsInRoom
                        .Include(s => s.Tickets) // Để tính BookedSeatsCount
                        .OrderBy(s => s.StartTime)
                        .Select(s => new ShowtimeBookingInfoModel
                        {
                            ShowtimeId = s.ShowtimeId,
                            StartTime = s.StartTime,
                            EndTime = s.EndTime,
                            RoomId = s.RoomId,
                            RoomName = s.CinemaRoom.RoomName,
                            TotalSeatsInRoom = s.CinemaRoom.Seats.Count(seat => seat.IsActive), // Chỉ đếm ghế active
                            BookedSeatsCount = s.Tickets.Count(t => t.Status != "cancelled")
                        })
                        .AsNoTracking()
                        .ToList();
                }
                AppUtils.WriteLine($"[EF Core] Found {showtimes.Count} showtimes for booking on {date:yyyy-MM-dd}.");
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimesForBooking (EF Core): {ex.Message}"); }
            return showtimes;
        }
        public List<int> GetBookedSeatIdsForShowtime(int showtimeId)
        {
            AppUtils.WriteLine($"[EF Core] Getting booked seats for Showtime ID: {showtimeId}");
            List<int> bookedSeatIds = new List<int>();
            try
            {
                using (var context = CreateContext())
                {
                    bookedSeatIds = context.Tickets
                                        .Where(t => t.ShowtimeId == showtimeId && t.Status != "cancelled")
                                        .Select(t => t.SeatId)
                                        .ToList();
                }
                AppUtils.WriteLine($"[EF Core] Found {bookedSeatIds.Count} booked seats for Showtime ID: {showtimeId}.");
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetBookedSeatIdsForShowtime (EF Core): {ex.Message}"); }
            return bookedSeatIds;
        }
        public List<SeatModel> GetSeatsByRoomId(int roomId)
        {
            AppUtils.WriteLine($"[EF Core] Getting seats for Room ID: {roomId}");
            List<SeatModel> seats = new List<SeatModel>();
            try
            {
                using (var context = CreateContext())
                {
                    var query = context.Seats
                                       .Where(s => s.RoomId == roomId)
                                       .Include(s => s.SeatType) 
                                       .AsNoTracking();

                    var loadedSeats = query.ToList();

                    seats = loadedSeats
                              .OrderBy(s => s.RowIdentifier) // Sắp xếp theo tên hàng (A, B, C...)
                              .ThenBy(s => {
                                  int seatNumValue;
                                  bool isNumeric = int.TryParse(s.SeatNumberInRow, out seatNumValue);
                                  return isNumeric ? seatNumValue : int.MaxValue; // Đẩy các giá trị không phải số xuống cuối
                              })
                              .ThenBy(s => s.SeatNumberInRow) // Sắp xếp phụ theo chuỗi gốc nếu số giống nhau hoặc không parse được
                              .ToList();
                }
                AppUtils.WriteLine($"[EF Core] Found {seats.Count} seats for Room ID: {roomId}.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in GetSeatsByRoomId (EF Core) for RoomID {roomId}: {ex.GetType().FullName} - {ex.Message}");
                AppUtils.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            return seats;
        }
        public List<FoodItemModel> GetAvailableFoodItems()
        {
            AppUtils.WriteLine("[EF Core] Getting available food items.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.FoodItems
                                  .Where(fi => fi.IsAvailable)
                                  .OrderBy(fi => fi.Category)
                                  .ThenBy(fi => fi.Name)
                                  .AsNoTracking()
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAvailableFoodItems (EF Core): {ex.Message}"); return new List<FoodItemModel>(); }
        }
        public OrderConfirmationModel CreateFullOrder(
                UserModel currentUser,
                ShowtimeBookingInfoModel selectedShowtime,
                List<SeatModel> selectedSeats,
                List<OrderFoodItemData> selectedFoodItems,
                List<SeatTypeModel> allSeatTypes)
        {
            if (currentUser == null || selectedShowtime == null || selectedSeats == null || !selectedSeats.Any() || allSeatTypes == null)
            {
                AppUtils.WriteLine("ERROR: [EF Core CreateFullOrder] Invalid input parameters.");
                return null;
            }
            AppUtils.WriteLine($"[EF Core] Creating full order for UserID: {currentUser.UserId}, ShowtimeID: {selectedShowtime.ShowtimeId}");
            OrderConfirmationModel confirmation = null;

            decimal subtotalTickets = 0;
            foreach (var seat in selectedSeats)
            {
                var seatType = allSeatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                subtotalTickets += seatType?.DefaultPrice ?? 0;
            }
            decimal subtotalFood = selectedFoodItems?.Sum(f => f.Subtotal) ?? 0;
            decimal totalAmount = subtotalTickets + subtotalFood;

            using (var context = CreateContext())
            using (var transaction = context.Database.BeginTransaction()) // Sử dụng transaction tường minh
            {
                try
                {
                    // 1. Tạo OrderModel
                    OrderModel newOrder = new OrderModel
                    {
                        UserId = currentUser.UserId,
                        OrderDateTime = DateTime.UtcNow,
                        SubtotalTickets = subtotalTickets,
                        SubtotalFood = subtotalFood,
                        TotalAmount = totalAmount,
                        Status = "paid",
                        PaymentMethod = "Online",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    context.Orders.Add(newOrder);
                    context.SaveChanges(); // Lưu để lấy OrderId
                    AppUtils.WriteLine($"[EF Core] Order created with ID: {newOrder.OrderId}");

                    // 2. Tạo Tickets
                    List<string> ticketCodesGenerated = new List<string>();
                    foreach (var seat in selectedSeats)
                    {
                        var seatType = allSeatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                        TicketModel ticket = new TicketModel
                        {
                            OrderId = newOrder.OrderId,
                            ShowtimeId = selectedShowtime.ShowtimeId,
                            SeatId = seat.SeatId,
                            PriceAtPurchase = seatType?.DefaultPrice ?? 0,
                            TicketCode = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
                            Status = "booked",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        context.Tickets.Add(ticket);
                        ticketCodesGenerated.Add(ticket.TicketCode);
                    }
                    context.SaveChanges(); // Lưu Tickets
                    AppUtils.WriteLine($"[EF Core] Added {selectedSeats.Count} tickets for Order ID: {newOrder.OrderId}");

                    // 3. Tạo OrderFoodItems (nếu có)
                    if (selectedFoodItems != null && selectedFoodItems.Any())
                    {
                        foreach (var foodData in selectedFoodItems)
                        {
                            OrderFoodItemModel orderFoodItem = new OrderFoodItemModel
                            {
                                OrderId = newOrder.OrderId,
                                FoodItemId = foodData.FoodItemId,
                                Quantity = foodData.Quantity,
                                PricePerItemAtPurchase = foodData.PricePerItem,
                                SubtotalForItem = foodData.Subtotal,
                                CreatedAt = DateTime.UtcNow
                            };
                            context.OrderFoodItems.Add(orderFoodItem);
                        }
                        context.SaveChanges(); // Lưu OrderFoodItems
                        AppUtils.WriteLine($"[EF Core] Added {selectedFoodItems.Count} types of food items for Order ID: {newOrder.OrderId}");
                    }

                    transaction.Commit();
                    AppUtils.WriteLine($"[EF Core] Full order transaction committed for Order ID: {newOrder.OrderId}");

                    MovieModel movieDetails = context.Movies.AsNoTracking().FirstOrDefault(m => m.MovieId == selectedShowtime.MovieId);
                    confirmation = new OrderConfirmationModel
                    {
                        OrderId = newOrder.OrderId,
                        MovieTitle = movieDetails?.Title ?? "N/A",
                        RoomName = selectedShowtime.RoomName,
                        ShowtimeStartTime = selectedShowtime.StartTime,
                        SeatCodes = selectedSeats.Select(s => $"{s.RowIdentifier}{s.SeatNumberInRow}").ToList(),
                        TicketCodes = ticketCodesGenerated,
                        TotalAmountPaid = totalAmount,
                        FoodItemsSummary = selectedFoodItems?.Select(f => $"{f.FoodItemName} x{f.Quantity}: {f.Subtotal:N0}đ").ToList() ?? new List<string>(),
                        OrderDateTime = newOrder.OrderDateTime
                    };
                }
                catch (Exception ex)
                {
                    AppUtils.WriteLine($"EXCEPTION in CreateFullOrder (EF Core): {ex.Message}\nStackTrace: {ex.StackTrace}");
                    try { transaction.Rollback(); AppUtils.WriteLine("[EF Core] Transaction rolled back."); }
                    catch (Exception rbEx) { AppUtils.WriteLine($"EXCEPTION during EF Core transaction rollback: {rbEx.Message}"); }
                    return null;
                }
            }
            return confirmation;
        }
        public List<BookedTicketInfoModel> GetTicketsByUserId(int userId)
        {
            AppUtils.WriteLine($"[EF Core] Getting tickets for UserID: {userId}");
            List<BookedTicketInfoModel> tickets = new List<BookedTicketInfoModel>();
            int sttCounter = 1;
            try
            {
                using (var context = CreateContext())
                {
                    tickets = context.Tickets
                        .Where(t => t.Order.UserId == userId) // Giả định Ticket có Order, Order có UserId
                        .Include(t => t.Order)
                        .Include(t => t.Showtime)
                            .ThenInclude(sh => sh.Movie)
                        .Include(t => t.Showtime)
                            .ThenInclude(sh => sh.CinemaRoom)
                        .Include(t => t.Seat)
                        .OrderByDescending(t => t.Order.OrderDateTime)
                        .ThenByDescending(t => t.Showtime.StartTime)
                        .Select(t => new BookedTicketInfoModel
                        {
                            // STT sẽ được gán sau khi ToList()
                            TicketId = t.TicketId,
                            TicketCode = t.TicketCode ?? "N/A",
                            PricePaid = t.PriceAtPurchase,
                            TicketStatus = t.Status,
                            OrderDate = t.Order.OrderDateTime,
                            ShowtimeStartTime = t.Showtime.StartTime,
                            MovieTitle = t.Showtime.Movie.Title,
                            RoomName = t.Showtime.CinemaRoom.RoomName,
                            SeatLocation = t.Seat.RowIdentifier + t.Seat.SeatNumberInRow
                        })
                        .AsNoTracking()
                        .ToList();

                    // Gán STT sau khi đã lấy và sắp xếp dữ liệu
                    for (int i = 0; i < tickets.Count; i++)
                    {
                        tickets[i].STT = i + 1;
                    }
                }
                AppUtils.WriteLine($"[EF Core] Found {tickets.Count} tickets for UserID: {userId}.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in GetTicketsByUserId (EF Core): {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
            return tickets;
        }
        public int GetTotalRoomCount()
        {
            AppUtils.WriteLine("[EF Core] Getting total room count.");
            try { using (var context = CreateContext()) return context.CinemaRooms.Count(r => r.Status == "active"); }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTotalRoomCount (EF Core): {ex.Message}"); return 0; }
        }

        public int GetTotalActiveSeatCount()
        {
            AppUtils.WriteLine("[EF Core] Getting total active seat count.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Seats
                                  .Where(s => s.IsActive && s.CinemaRoom.Status == "active") // Giả định SeatModel có nav prop CinemaRoom
                                  .Count();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTotalActiveSeatCount (EF Core): {ex.Message}"); return 0; }
        }

        public List<SeatTypeStat> GetSeatCountByType()
        {
            AppUtils.WriteLine("[EF Core] Getting seat count by type.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Seats
                                  .Where(s => s.IsActive && s.CinemaRoom.Status == "active") // Chỉ ghế active trong phòng active
                                  .Include(s => s.SeatType) // Nạp thông tin SeatType
                                  .GroupBy(s => new { s.SeatType.SeatTypeId, s.SeatType.TypeName, s.SeatType.DisplayColorHex })
                                  .Select(g => new SeatTypeStat
                                  {
                                      SeatTypeName = g.Key.TypeName,
                                      Count = g.Count(),
                                      DisplayColorHex = g.Key.DisplayColorHex
                                  })
                                  .OrderBy(s => s.SeatTypeName)
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetSeatCountByType (EF Core): {ex.Message}"); return new List<SeatTypeStat>(); }
        }

        public List<MovieStatusStat> GetMovieCountByStatus()
        {
            AppUtils.WriteLine("[EF Core] Getting movie count by status.");
            try
            {
                using (var context = CreateContext())
                {
                    return context.Movies
                                  .GroupBy(m => m.Status)
                                  .Select(g => new MovieStatusStat
                                  {
                                      Status = g.Key,
                                      Count = g.Count()
                                  })
                                  .OrderBy(s => s.Status)
                                  .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetMovieCountByStatus (EF Core): {ex.Message}"); return new List<MovieStatusStat>(); }
        }

        public decimal GetTotalTicketRevenueForPeriod(DateTime startDate, DateTime endDate)
        {
            AppUtils.WriteLine($"[EF Core] Getting total ticket revenue from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}.");
            try
            {
                using (var context = CreateContext())
                {
                    DateTime endDatePlusOne = endDate.Date.AddDays(1);
                    return context.Tickets
                                  .Where(t => (t.Status == "booked" || t.Status == "checked_in") &&
                                              (t.Order.Status == "paid" || t.Order.Status == "completed") && // Giả định Ticket có nav prop Order
                                              t.Order.OrderDateTime >= startDate.Date && t.Order.OrderDateTime < endDatePlusOne)
                                  .Sum(t => t.PriceAtPurchase);
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTotalTicketRevenueForPeriod (EF Core): {ex.Message}"); return 0; }
        }

        public RevenueDetailsStat GetRevenueDetailsForPeriod(DateTime startDate, DateTime endDate)
        {
            AppUtils.WriteLine($"[EF Core] Getting revenue details for period: {startDate:d} - {endDate:d}");
            var stats = new RevenueDetailsStat();
            DateTime endDatePlusOne = endDate.Date.AddDays(1);
            try
            {
                using (var context = CreateContext())
                {
                    var validOrders = context.Orders
                        .Where(o => (o.Status == "paid" || o.Status == "completed") &&
                                    o.OrderDateTime >= startDate.Date && o.OrderDateTime < endDatePlusOne);

                    stats.TicketRevenue = validOrders
                        .SelectMany(o => o.Tickets) // Giả định OrderModel có ICollection<TicketModel> Tickets
                        .Where(t => t.Status != "cancelled")
                        .Sum(t => (decimal?)t.PriceAtPurchase) ?? 0; // Sum có thể trả về null nếu không có item

                    stats.FoodAndBeverageRevenue = validOrders
                        .SelectMany(o => o.OrderFoodItems) // Giả định OrderModel có ICollection<OrderFoodItemModel> OrderFoodItems
                        .Sum(ofi => (decimal?)ofi.SubtotalForItem) ?? 0;

                    stats.TotalOrderSumRevenue = validOrders
                        .Sum(o => (decimal?)o.TotalAmount) ?? 0;
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetRevenueDetailsForPeriod (EF Core): {ex.Message}"); }
            return stats;
        }

        public List<PopularFoodItemStat> GetMostPopularFoodItems(DateTime startDate, DateTime endDate, int topN)
        {
            AppUtils.WriteLine($"[EF Core] Getting Top {topN} popular food items for period: {startDate:d} - {endDate:d}");
            DateTime endDatePlusOne = endDate.Date.AddDays(1);
            try
            {
                using (var context = CreateContext())
                {
                    return context.OrderFoodItems
                        .Where(ofi => (ofi.Order.Status == "paid" || ofi.Order.Status == "completed") &&
                                      ofi.Order.OrderDateTime >= startDate.Date && ofi.Order.OrderDateTime < endDatePlusOne)
                        .Include(ofi => ofi.FoodItem) // Giả định OrderFoodItemModel có FoodItemModel FoodItem
                        .GroupBy(ofi => new { ofi.FoodItemId, ofi.FoodItem.Name })
                        .Select(g => new PopularFoodItemStat
                        {
                            FoodItemName = g.Key.Name,
                            TotalQuantitySold = g.Sum(x => x.Quantity)
                        })
                        .OrderByDescending(x => x.TotalQuantitySold)
                        .ThenBy(x => x.FoodItemName)
                        .Take(topN)
                        .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetMostPopularFoodItems (EF Core): {ex.Message}"); return new List<PopularFoodItemStat>(); }
        }

        public List<SeatTypeSalesStat> GetTicketSalesBySeatType(DateTime startDate, DateTime endDate)
        {
            AppUtils.WriteLine($"[EF Core] Getting ticket sales by seat type for period: {startDate:d} - {endDate:d}");
            DateTime endDatePlusOne = endDate.Date.AddDays(1);
            try
            {
                using (var context = CreateContext())
                {
                    return context.Tickets
                        .Where(t => t.Status != "cancelled" &&
                                    (t.Order.Status == "paid" || t.Order.Status == "completed") &&
                                    t.Order.OrderDateTime >= startDate.Date && t.Order.OrderDateTime < endDatePlusOne)
                        .Include(t => t.Seat)
                            .ThenInclude(s => s.SeatType) // Giả định SeatModel có SeatTypeModel SeatType
                        .GroupBy(t => new { t.Seat.SeatTypeId, t.Seat.SeatType.TypeName })
                        .Select(g => new SeatTypeSalesStat
                        {
                            SeatTypeName = g.Key.TypeName,
                            TicketsSold = g.Count()
                        })
                        .OrderByDescending(x => x.TicketsSold)
                        .ThenBy(x => x.SeatTypeName)
                        .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTicketSalesBySeatType (EF Core): {ex.Message}"); return new List<SeatTypeSalesStat>(); }
        }

        public int GetTotalTicketsSoldForPeriod(DateTime startDate, DateTime endDate)
        {
            AppUtils.WriteLine($"[EF Core] Getting total tickets sold for period: {startDate:d} - {endDate:d}");
            DateTime endDatePlusOne = endDate.Date.AddDays(1);
            try
            {
                using (var context = CreateContext())
                {
                    return context.Tickets
                        .Count(t => t.Status != "cancelled" &&
                                     (t.Order.Status == "paid" || t.Order.Status == "completed") &&
                                     t.Order.OrderDateTime >= startDate.Date && t.Order.OrderDateTime < endDatePlusOne);
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTotalTicketsSoldForPeriod (EF Core): {ex.Message}"); return 0; }
        }

        public List<MovieSalesStat> GetTicketSalesByMovie(DateTime startDate, DateTime endDate)
        {
            AppUtils.WriteLine($"[EF Core] Getting ticket sales by movie for period: {startDate:d} - {endDate:d}");
            DateTime endDatePlusOne = endDate.Date.AddDays(1);
            try
            {
                using (var context = CreateContext())
                {
                    return context.Tickets
                        .Where(t => t.Status != "cancelled" &&
                                    (t.Order.Status == "paid" || t.Order.Status == "completed") &&
                                    t.Order.OrderDateTime >= startDate.Date && t.Order.OrderDateTime < endDatePlusOne)
                        .Include(t => t.Showtime)
                            .ThenInclude(sh => sh.Movie) // Giả định ShowtimeModel có MovieModel Movie
                        .GroupBy(t => new { t.Showtime.MovieId, t.Showtime.Movie.Title })
                        .Select(g => new MovieSalesStat
                        {
                            MovieTitle = g.Key.Title,
                            TicketsSold = g.Count()
                        })
                        .OrderByDescending(x => x.TicketsSold)
                        .ThenBy(x => x.MovieTitle)
                        .ToList();
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetTicketSalesByMovie (EF Core): {ex.Message}"); return new List<MovieSalesStat>(); }
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<SeatTypeModel> SeatTypes { get; set; }
        public DbSet<CinemaRoomModel> CinemaRooms { get; set; }
        public DbSet<SeatModel> Seats { get; set; }
        public DbSet<ShowtimeModel> Showtimes { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<FoodItemModel> FoodItems { get; set; }
        public DbSet<OrderFoodItemModel> OrderFoodItems { get; set; }
        public DbSet<PromotionModel> Promotions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Cấu hình cho UserModel ---
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("user_id").ValueGeneratedOnAdd();
                entity.Property(e => e.Username).HasColumnName("username").IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Password).HasColumnName("password").IsRequired(); // Nên là PasswordHash
                entity.Property(e => e.Email).HasColumnName("email").IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FullName).HasColumnName("full_name").HasMaxLength(255);
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(50);
                entity.Property(e => e.Role).HasColumnName("role").IsRequired().HasMaxLength(50); // Trước đó là nvarchar(10)
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
            });

            // --- Cấu hình cho MovieModel ---
            modelBuilder.Entity<MovieModel>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.MovieId);
                entity.Property(e => e.MovieId).HasColumnName("movie_id").ValueGeneratedOnAdd();
                entity.Property(e => e.Title).HasColumnName("title").IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Director).HasColumnName("director").HasMaxLength(255);
                entity.Property(e => e.Actors).HasColumnName("actors");
                entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes").IsRequired();
                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
                entity.Property(e => e.PosterImageUrl).HasColumnName("poster_image_url").HasMaxLength(2048);
                entity.Property(e => e.TrailerUrl).HasColumnName("trailer_url").HasMaxLength(2048);
                entity.Property(e => e.Genre).HasColumnName("genre").HasMaxLength(255);
                entity.Property(e => e.Language).HasColumnName("language").HasMaxLength(100);
                entity.Property(e => e.RatingDetails).HasColumnName("rating_details").HasMaxLength(50);
                entity.Property(e => e.Status).HasColumnName("status").IsRequired().HasMaxLength(10);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
            });

            // --- Cấu hình cho SeatTypeModel ---
            modelBuilder.Entity<SeatTypeModel>(entity =>
            {
                entity.ToTable("SeatTypes");
                entity.HasKey(e => e.SeatTypeId);
                entity.Property(e => e.SeatTypeId).HasColumnName("seat_type_id").ValueGeneratedOnAdd();
                entity.Property(e => e.TypeName).HasColumnName("type_name").IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.TypeName).IsUnique();
                entity.Property(e => e.DefaultPrice).HasColumnName("default_price").HasColumnType("decimal(10, 0)").IsRequired();
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DisplayColorHex).HasColumnName("display_color_hex").HasMaxLength(7);
            });

            // --- Cấu hình cho CinemaRoomModel ---
            modelBuilder.Entity<CinemaRoomModel>(entity =>
            {
                entity.ToTable("CinemaRooms");
                entity.HasKey(e => e.RoomId);
                entity.Property(e => e.RoomId).HasColumnName("room_id").ValueGeneratedOnAdd();
                entity.Property(e => e.RoomName).HasColumnName("room_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.RoomLayoutDescription).HasColumnName("room_layout_description");
                entity.Property(e => e.Status).HasColumnName("status").IsRequired().HasMaxLength(20).HasDefaultValue("active");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
            });

            // --- Cấu hình cho SeatModel ---
            modelBuilder.Entity<SeatModel>(entity =>
            {
                entity.ToTable("Seats");
                entity.HasKey(e => e.SeatId);
                entity.Property(e => e.SeatId).HasColumnName("seat_id").ValueGeneratedOnAdd();
                entity.Property(e => e.RoomId).HasColumnName("room_id").IsRequired();
                entity.Property(e => e.SeatTypeId).HasColumnName("seat_type_id").IsRequired();
                entity.Property(e => e.RowIdentifier).HasColumnName("row_identifier").IsRequired().HasMaxLength(10);
                entity.Property(e => e.SeatNumberInRow).HasColumnName("seat_number_in_row").IsRequired().HasMaxLength(10);
                entity.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);

                entity.HasIndex(e => new { e.RoomId, e.RowIdentifier, e.SeatNumberInRow }).IsUnique().HasDatabaseName("UQ_Seats_RoomPosition");

                entity.HasOne<CinemaRoomModel>()
                      .WithMany()
                      .HasForeignKey(s => s.RoomId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<SeatTypeModel>()
                      .WithMany()
                      .HasForeignKey(s => s.SeatTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- Cấu hình cho ShowtimeModel ---
            modelBuilder.Entity<ShowtimeModel>(entity =>
            {
                entity.ToTable("Showtimes");
                entity.HasKey(e => e.ShowtimeId);
                entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id").ValueGeneratedOnAdd();
                entity.Property(e => e.MovieId).HasColumnName("movie_id").IsRequired();
                entity.Property(e => e.RoomId).HasColumnName("room_id").IsRequired();
                entity.Property(e => e.StartTime).HasColumnName("start_time").IsRequired();
                entity.Property(e => e.EndTime).HasColumnName("end_time").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => new { e.RoomId, e.StartTime }).IsUnique().HasDatabaseName("UQ_Showtimes_RoomTime");

                entity.HasOne<MovieModel>().WithMany().HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<CinemaRoomModel>().WithMany().HasForeignKey(s => s.RoomId).OnDelete(DeleteBehavior.Restrict);
            });

            // --- Cấu hình cho OrderModel ---
            modelBuilder.Entity<OrderModel>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasColumnName("order_id").ValueGeneratedOnAdd();
                entity.Property(e => e.UserId).HasColumnName("user_id").IsRequired();
                entity.Property(e => e.OrderDateTime).HasColumnName("order_datetime").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.SubtotalTickets).HasColumnName("subtotal_tickets").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.SubtotalFood).HasColumnName("subtotal_food").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.PromotionId).HasColumnName("promotion_id"); // Nullable
                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.AmountBeforeVat).HasColumnName("amount_before_vat").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.VatPercentage).HasColumnName("vat_percentage").HasColumnType("decimal(5,2)").HasDefaultValue(8.00m);
                entity.Property(e => e.VatAmount).HasColumnName("vat_amount").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.TotalAmount).HasColumnName("total_amount").HasColumnType("decimal(10,0)").HasDefaultValue(0);
                entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(20).HasDefaultValue("pending_payment");
                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method").HasMaxLength(50);
                entity.Property(e => e.PaymentTransactionId).HasColumnName("payment_transaction_id").HasMaxLength(255);
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");

                entity.HasOne<UserModel>().WithMany().HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<PromotionModel>().WithMany().HasForeignKey(o => o.PromotionId).OnDelete(DeleteBehavior.SetNull); // Hoặc Restrict
            });

            // --- Cấu hình cho TicketModel ---
            modelBuilder.Entity<TicketModel>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(e => e.TicketId);
                entity.Property(e => e.TicketId).HasColumnName("ticket_id").ValueGeneratedOnAdd();
                entity.Property(e => e.OrderId).HasColumnName("order_id").IsRequired();
                entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id").IsRequired();
                entity.Property(e => e.SeatId).HasColumnName("seat_id").IsRequired();
                entity.Property(e => e.PriceAtPurchase).HasColumnName("price_at_purchase").HasColumnType("decimal(10,0)").IsRequired();
                entity.Property(e => e.TicketCode).HasColumnName("ticket_code").HasMaxLength(255);
                entity.HasIndex(e => e.TicketCode).IsUnique().HasFilter("[ticket_code] IS NOT NULL"); // Unique nếu không null
                entity.Property(e => e.Status).HasColumnName("status").HasMaxLength(15).HasDefaultValue("booked");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => new { e.ShowtimeId, e.SeatId }).IsUnique().HasDatabaseName("UQ_Tickets_ShowtimeSeat");

                entity.HasOne<OrderModel>().WithMany(/* t => t.Tickets */).HasForeignKey(t => t.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<ShowtimeModel>().WithMany().HasForeignKey(t => t.ShowtimeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<SeatModel>().WithMany().HasForeignKey(t => t.SeatId).OnDelete(DeleteBehavior.Restrict);
            });

            // --- Cấu hình cho FoodItemModel ---
            modelBuilder.Entity<FoodItemModel>(entity =>
            {
                entity.ToTable("FoodItems");
                entity.HasKey(e => e.FoodItemId);
                entity.Property(e => e.FoodItemId).HasColumnName("food_item_id").ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(10,0)").IsRequired();
                entity.Property(e => e.ImageUrl).HasColumnName("image_url").HasMaxLength(2048);
                entity.Property(e => e.Category).HasColumnName("category").HasMaxLength(100);
                entity.Property(e => e.IsAvailable).HasColumnName("is_available").HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
            });

            // --- Cấu hình cho OrderFoodItemModel ---
            modelBuilder.Entity<OrderFoodItemModel>(entity =>
            {
                entity.ToTable("OrderFoodItems");
                entity.HasKey(e => e.OrderFoodItemId);
                entity.Property(e => e.OrderFoodItemId).HasColumnName("order_food_item_id").ValueGeneratedOnAdd();
                entity.Property(e => e.OrderId).HasColumnName("order_id").IsRequired();
                entity.Property(e => e.FoodItemId).HasColumnName("food_item_id").IsRequired();
                entity.Property(e => e.Quantity).HasColumnName("quantity").HasDefaultValue(1);
                entity.Property(e => e.PricePerItemAtPurchase).HasColumnName("price_per_item_at_purchase").HasColumnType("decimal(10,0)").IsRequired();
                entity.Property(e => e.SubtotalForItem).HasColumnName("subtotal_for_item").HasColumnType("decimal(10,0)").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => new { e.OrderId, e.FoodItemId }).IsUnique().HasDatabaseName("UQ_OrderFoodItems_OrderItem");

                entity.HasOne<OrderModel>().WithMany(/* o => o.OrderFoodItems */).HasForeignKey(ofi => ofi.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<FoodItemModel>().WithMany().HasForeignKey(ofi => ofi.FoodItemId).OnDelete(DeleteBehavior.Restrict);
            });

            // --- Cấu hình cho PromotionModel ---
            modelBuilder.Entity<PromotionModel>(entity =>
            {
                entity.ToTable("Promotions");
                entity.HasKey(e => e.PromotionId);
                entity.Property(e => e.PromotionId).HasColumnName("promotion_id").ValueGeneratedOnAdd();
                entity.Property(e => e.Code).HasColumnName("code").IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.Code).IsUnique();
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.DiscountType).HasColumnName("discount_type").IsRequired().HasMaxLength(15);
                entity.Property(e => e.DiscountValue).HasColumnName("discount_value").HasColumnType("decimal(10,2)").IsRequired(); // Để ý scale
                entity.Property(e => e.MaxDiscountAmount).HasColumnName("max_discount_amount").HasColumnType("decimal(10,0)");
                entity.Property(e => e.StartDate).HasColumnName("start_date").IsRequired();
                entity.Property(e => e.EndDate).HasColumnName("end_date").IsRequired();
                entity.Property(e => e.UsageLimitPerUser).HasColumnName("usage_limit_per_user");
                entity.Property(e => e.TotalUsageLimit).HasColumnName("total_usage_limit");
                entity.Property(e => e.MinOrderValue).HasColumnName("min_order_value").HasColumnType("decimal(10,0)");
                entity.Property(e => e.ApplicableTo).HasColumnName("applicable_to").HasMaxLength(15).HasDefaultValue("all");
                entity.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
