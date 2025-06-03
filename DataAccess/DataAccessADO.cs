using CinemaApplication.Enums;
using CinemaApplication.Interfaces;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace CinemaApplication.DataAccess
{
    public class DataAccessADO : IDataAccess
    {
        private readonly string _connectionString;

        public DataAccessADO(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty for ADO.NET.");
            }
            AppUtils.WriteLine("DataAccessADO initialized with connection string: " + connectionString);
            _connectionString = connectionString;
        }

        public bool RegisterUser(UserModel user)
        {
            AppUtils.WriteLine($"[ADO.NET] Attempting to register user: {user.Username}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                        INSERT INTO Users (username, password, email, full_name, phone_number, role, created_at, updated_at)
                        VALUES (@Username, @Password, @Email, @FullName, @PhoneNumber, @Role, @CreatedAt, @UpdatedAt);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@FullName", (object)user.FullName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PhoneNumber", (object)user.PhoneNumber ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Role", user.Role ?? UserRoleEnum.user.ToString());
                        command.Parameters.AddWithValue("@CreatedAt", (object)user.CreatedAt ?? (object)DateTime.Now);
                        command.Parameters.AddWithValue("@UpdatedAt", (object)user.UpdatedAt ?? (object)DateTime.Now);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        connection.Close();

                        if (result != null)
                        {
                            try
                            {
                                user.UserId = Convert.ToInt32(result); // Assign the new UserId back to the model
                                AppUtils.WriteLine($"[ADO.NET] User '{user.Username}' registered successfully with ID: {user.UserId}.");
                                return true;
                            }
                            catch (Exception ex)
                            {
                                AppUtils.WriteLine($"[ADO.NET] User '{user.Username}' registered, but failed to convert ID: {result}. Error: {ex.Message}");
                                return true; // Still registered, but ID conversion failed.
                            }
                        }
                        AppUtils.WriteLine($"[ADO.NET] Failed to register user '{user.Username}'. No ID returned.");
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                AppUtils.WriteLine($"[ADO.NET] SQL Error registering user '{user.Username}'. Number: {ex.Number}, Message: {ex.Message}");
                if (ex.Number == 2627 || ex.Number == 2601) // UNIQUE constraint violation
                {
                    AppUtils.WriteLine($"[ADO.NET] Username or Email already exists for '{user.Username}'.");
                }
                return false;
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[ADO.NET] General Error registering user '{user.Username}'");
                return false;
            }
        }

        public UserModel AuthenticateUser(string username, string plainTextPassword)
        {
            AppUtils.WriteLine($"[ADO.NET] Attempting to authenticate user: {username}");
            UserModel user = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Select all columns that match UserModel properties and dbo.Users table
                    string query = @"SELECT user_id, username, password, email, full_name, 
                                            phone_number, role, created_at, updated_at 
                                     FROM Users WHERE username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["password"].ToString();
                                if (plainTextPassword == storedPassword)
                                {
                                    user = new UserModel
                                    {
                                        UserId = Convert.ToInt32(reader["user_id"]),
                                        Username = reader["username"].ToString(),
                                        Password = storedPassword,
                                        Email = reader["email"].ToString(),
                                        FullName = reader["full_name"] != DBNull.Value ? reader["full_name"].ToString() : null,
                                        PhoneNumber = reader["phone_number"] != DBNull.Value ? reader["phone_number"].ToString() : null,
                                        Role = reader["role"].ToString(),
                                        CreatedAt = Convert.ToDateTime(reader["Created_At"]),
                                        UpdatedAt = Convert.ToDateTime(reader["Updated_At"])
                                    };
                                    AppUtils.WriteLine($"[ADO.NET] User '{username}' authenticated successfully.");
                                }
                                else
                                {
                                    AppUtils.WriteLine($"[ADO.NET] Authentication failed for user '{username}': Password mismatch.");
                                }
                            }
                            else
                            {
                                AppUtils.WriteLine($"[ADO.NET] Authentication failed: User '{username}' not found.");
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                AppUtils.WriteLine($"[ADO.NET] SQL Error authenticating user '{username}'. Number: {ex.Number}, Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[ADO.NET] General Error authenticating user '{username}'");
            }
            return user;
        }
        public List<MovieModel> GetMoviesByStatus(string status)
        {
            List<MovieModel> movies = new List<MovieModel>();
            AppUtils.WriteLine($"[ADO.NET] Attempting to get movies with status: {status}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT movie_id, title, description, director, actors, 
                                    duration_minutes, release_date, poster_image_url, 
                                    trailer_url, genre, language, rating_details, status,
                                    created_at, updated_at
                             FROM Movies 
                             WHERE status = @Status
                             ORDER BY release_date DESC";// Sắp xếp theo ngày phát hành mới nhất

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MovieModel movie = new MovieModel
                                {
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                    Director = reader["director"] != DBNull.Value ? reader["director"].ToString() : null,
                                    Actors = reader["actors"] != DBNull.Value ? reader["actors"].ToString() : null,
                                    DurationMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                    ReleaseDate = reader["release_date"] != DBNull.Value ? Convert.ToDateTime(reader["release_date"]) : (DateTime?)null,
                                    PosterImageUrl = reader["poster_image_url"] != DBNull.Value ? reader["poster_image_url"].ToString() : null,
                                    TrailerUrl = reader["trailer_url"] != DBNull.Value ? reader["trailer_url"].ToString() : null,
                                    Genre = reader["genre"] != DBNull.Value ? reader["genre"].ToString() : null,
                                    Language = reader["language"] != DBNull.Value ? reader["language"].ToString() : null,
                                    RatingDetails = reader["rating_details"] != DBNull.Value ? reader["rating_details"].ToString() : null,
                                    Status = reader["status"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"]) 
                                };
                                movies.Add(movie);
                            }
                        }
                        connection.Close();
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {movies.Count} movies with status: {status}");
            }
            catch (SqlException ex)
            {
                AppUtils.WriteLine($"[ADO.NET] SQL Error getting movies by status '{status}'. Number: {ex.Number}, Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[ADO.NET] General Error getting movies by status '{status}'");
            }
            return movies;
        }
        public List<SeatTypeModel> GetAllSeatTypes()
        {
            List<SeatTypeModel> seatTypes = new List<SeatTypeModel>();
            AppUtils.WriteLine("[ADO.NET] Attempting to get all seat types.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT seat_type_id, type_name, default_price, description, display_color_hex FROM SeatTypes ORDER BY type_name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                seatTypes.Add(new SeatTypeModel
                                {
                                    SeatTypeId = Convert.ToInt32(reader["seat_type_id"]),
                                    TypeName = reader["type_name"].ToString(),
                                    DefaultPrice = Convert.ToDecimal(reader["default_price"]),
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                    DisplayColorHex = reader["display_color_hex"] != DBNull.Value ? reader["display_color_hex"].ToString() : null
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {seatTypes.Count} seat types.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[ADO.NET] Error getting all seat types");
            }
            return seatTypes;
        }
        public int AddCinemaRoom(CinemaRoomModel room)
        {
            AppUtils.WriteLine($"[ADO.NET] Attempting to add cinema room: {room.RoomName}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                INSERT INTO CinemaRooms (room_name, room_layout_description, status, created_at, updated_at)
                OUTPUT INSERTED.room_id 
                VALUES (@RoomName, @RoomLayoutDescription, @Status, @CreatedAt, @UpdatedAt);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomName", room.RoomName);
                        command.Parameters.AddWithValue("@RoomLayoutDescription", (object)room.RoomLayoutDescription ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Status", room.Status ?? "active");
                        command.Parameters.AddWithValue("@CreatedAt", room.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", room.UpdatedAt);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int newRoomId = Convert.ToInt32(result);
                            AppUtils.WriteLine($"[ADO.NET] Cinema room '{room.RoomName}' added successfully with ID: {newRoomId}.");
                            return newRoomId;
                        }
                        AppUtils.WriteLine($"[ADO.NET] Failed to add cinema room '{room.RoomName}'. No ID returned.");
                        return -1; // Hoặc ném exception
                    }
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[ADO.NET] Error adding cinema room '{room.RoomName}'");
                return -1; // Hoặc ném exception
            }
        }
        public bool AddSeats(List<SeatModel> seats)
        {
            if (seats == null || !seats.Any()) return true;

            AppUtils.WriteLine($"[ADO.NET] Attempting to add {seats.Count} seats.");
            int successCount = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                connection.Open();

                foreach (var seat in seats)
                {
                    string query = @"
                INSERT INTO Seats (room_id, seat_type_id, row_identifier, seat_number_in_row, is_active)
                VALUES (@RoomId, @SeatTypeId, @RowIdentifier, @SeatNumberInRow, @IsActive);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomId", seat.RoomId);
                        command.Parameters.AddWithValue("@SeatTypeId", seat.SeatTypeId);
                        command.Parameters.AddWithValue("@RowIdentifier", seat.RowIdentifier);
                        command.Parameters.AddWithValue("@SeatNumberInRow", seat.SeatNumberInRow);
                        command.Parameters.AddWithValue("@IsActive", seat.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            successCount++;
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Successfully added {successCount} out of {seats.Count} seats.");
                return successCount == seats.Count;
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[ADO.NET] Error adding seats in bulk");
                return false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<MovieModel> GetAllMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();
            AppUtils.WriteLine("[ADO.NET] Getting all movies.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT movie_id, title, director, duration_minutes, release_date, 
                                    genre, rating_details, status, created_at 
                             FROM Movies ORDER BY release_date DESC, title ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movies.Add(new MovieModel
                                {
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    Title = reader["title"].ToString(),
                                    Director = reader["director"] != DBNull.Value ? reader["director"].ToString() : null,
                                    DurationMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                    ReleaseDate = reader["release_date"] != DBNull.Value ? Convert.ToDateTime(reader["release_date"]) : (DateTime?)null,
                                    Genre = reader["genre"] != DBNull.Value ? reader["genre"].ToString() : null,
                                    RatingDetails = reader["rating_details"] != DBNull.Value ? reader["rating_details"].ToString() : null,
                                    Status = reader["status"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]) // Giả sử CreatedAt không null
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {movies.Count} movies.");
            }
            catch (Exception ex) { AppUtils.WriteLine("[ADO.NET] Error getting all movies"); }
            return movies;
        }
        public int AddMovie(MovieModel movie)
        {
            AppUtils.WriteLine($"[ADO.NET] Adding new movie: {movie.Title}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                INSERT INTO Movies (title, description, director, actors, duration_minutes, 
                                    release_date, poster_image_url, trailer_url, genre, 
                                    language, rating_details, status, created_at, updated_at)
                VALUES (@Title, @Description, @Director, @Actors, @DurationMinutes, 
                        @ReleaseDate, @PosterImageUrl, @TrailerUrl, @Genre, 
                        @Language, @RatingDetails, @Status, @CreatedAt, @UpdatedAt);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"; // Lấy MovieId mới

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", movie.Title);
                        command.Parameters.AddWithValue("@Description", (object)movie.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Director", (object)movie.Director ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Actors", (object)movie.Actors ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DurationMinutes", movie.DurationMinutes);
                        command.Parameters.AddWithValue("@ReleaseDate", (object)movie.ReleaseDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PosterImageUrl", (object)movie.PosterImageUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TrailerUrl", (object)movie.TrailerUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Genre", (object)movie.Genre ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Language", (object)movie.Language ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RatingDetails", (object)movie.RatingDetails ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Status", movie.Status);
                        command.Parameters.AddWithValue("@CreatedAt", movie.CreatedAt == DateTime.MinValue ? DateTime.Now : movie.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", movie.UpdatedAt == DateTime.MinValue ? DateTime.Now : movie.UpdatedAt);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int newMovieId = Convert.ToInt32(result);
                            AppUtils.WriteLine($"[ADO.NET] Movie '{movie.Title}' added successfully with ID: {newMovieId}.");
                            return newMovieId;
                        }
                        AppUtils.WriteLine($"[ADO.NET] Failed to add movie '{movie.Title}'. No ID returned.");
                        return 0; // Hoặc -1 để chỉ lỗi
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"[ADO.NET] Error adding movie '{movie.Title}'"); return 0; }
        }
        public bool UpdateMovie(MovieModel movie)
        {
            AppUtils.WriteLine($"[ADO.NET] Updating movie ID: {movie.MovieId} - {movie.Title}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                UPDATE Movies SET 
                    title = @Title, description = @Description, director = @Director, 
                    actors = @Actors, duration_minutes = @DurationMinutes, release_date = @ReleaseDate, 
                    poster_image_url = @PosterImageUrl, trailer_url = @TrailerUrl, genre = @Genre, 
                    language = @Language, rating_details = @RatingDetails, status = @Status,
                    updated_at = @UpdatedAt 
                WHERE movie_id = @MovieId;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movie.MovieId);
                        command.Parameters.AddWithValue("@Title", movie.Title);
                        command.Parameters.AddWithValue("@Description", (object)movie.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Director", (object)movie.Director ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Actors", (object)movie.Actors ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DurationMinutes", movie.DurationMinutes);
                        command.Parameters.AddWithValue("@ReleaseDate", (object)movie.ReleaseDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PosterImageUrl", (object)movie.PosterImageUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TrailerUrl", (object)movie.TrailerUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Genre", (object)movie.Genre ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Language", (object)movie.Language ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RatingDetails", (object)movie.RatingDetails ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Status", movie.Status);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now); // Luôn cập nhật UpdatedAt

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        AppUtils.WriteLine($"[ADO.NET] Movie ID {movie.MovieId} update. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"[ADO.NET] Error updating movie ID {movie.MovieId}"); return false; }
        }
        public bool DeleteMovie(int movieId)
        {
            AppUtils.WriteLine($"[ADO.NET] Deleting movie ID: {movieId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Cân nhắc: Kiểm tra xem phim có suất chiếu không trước khi xóa, hoặc dùng ON DELETE CASCADE/SET NULL
                    string query = "DELETE FROM Movies WHERE movie_id = @MovieId;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        AppUtils.WriteLine($"[ADO.NET] Movie ID {movieId} delete. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Không thể xóa phim này vì có thể đang được sử dụng trong các suất chiếu hoặc dữ liệu khác.\nChi tiết: {ex.Message}", "Lỗi Xóa Phim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex) { AppUtils.WriteLine($"[ADO.NET] Error deleting movie ID {movieId}"); return false; }
        }
        public List<CinemaRoomStatsModel> GetAllCinemaRoomsWithStats()
        {
            List<CinemaRoomStatsModel> roomStatsList = new List<CinemaRoomStatsModel>();
            AppUtils.WriteLine("[ADO.NET] Getting all cinema rooms with stats.");
            int sttCounter = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                SELECT
                    cr.room_id,
                    cr.room_name,
                    cr.status,
                    cr.created_at,
                    COUNT(s.seat_id) AS TotalSeats,
                    SUM(CASE WHEN st.type_name = 'Standard' THEN 1 ELSE 0 END) AS StandardSeats,
                    SUM(CASE WHEN st.type_name = 'VIP' THEN 1 ELSE 0 END) AS VipSeats,
                    SUM(CASE WHEN st.type_name = 'Couple' THEN 1 ELSE 0 END) AS CoupleSeats
                FROM CinemaRooms cr
                LEFT JOIN Seats s ON cr.room_id = s.room_id
                LEFT JOIN SeatTypes st ON s.seat_type_id = st.seat_type_id
                GROUP BY
                    cr.room_id,
                    cr.room_name,
                    cr.status,
                    cr.created_at
                ORDER BY
                    cr.room_name;
            ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roomStatsList.Add(new CinemaRoomStatsModel
                                {
                                    STT = sttCounter++,
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    RoomName = reader["room_name"].ToString(),
                                    Status = reader["status"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    TotalSeats = Convert.ToInt32(reader["TotalSeats"]),
                                    StandardSeats = Convert.ToInt32(reader["StandardSeats"]),
                                    VipSeats = Convert.ToInt32(reader["VipSeats"]),
                                    CoupleSeats = Convert.ToInt32(reader["CoupleSeats"])
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {roomStatsList.Count} cinema rooms with stats.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine("[ADO.NET] Error getting all cinema rooms with stats");
            }
            return roomStatsList;
        }
        public MovieModel GetMovieById(int movieId)
        {
            MovieModel movie = null;
            AppUtils.WriteLine($"[ADO.NET] Attempting to get movie by ID: {movieId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT movie_id, title, description, director, actors, 
                                            duration_minutes, release_date, poster_image_url, 
                                            trailer_url, genre, language, rating_details, status,
                                            created_at, updated_at
                                     FROM Movies 
                                     WHERE movie_id = @MovieId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                movie = new MovieModel
                                {
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                    Director = reader["director"] != DBNull.Value ? reader["director"].ToString() : null,
                                    Actors = reader["actors"] != DBNull.Value ? reader["actors"].ToString() : null,
                                    DurationMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                    ReleaseDate = reader["release_date"] != DBNull.Value ? Convert.ToDateTime(reader["release_date"]) : (DateTime?)null,
                                    PosterImageUrl = reader["poster_image_url"] != DBNull.Value ? reader["poster_image_url"].ToString() : null,
                                    TrailerUrl = reader["trailer_url"] != DBNull.Value ? reader["trailer_url"].ToString() : null,
                                    Genre = reader["genre"] != DBNull.Value ? reader["genre"].ToString() : null,
                                    Language = reader["language"] != DBNull.Value ? reader["language"].ToString() : null,
                                    RatingDetails = reader["rating_details"] != DBNull.Value ? reader["rating_details"].ToString() : null,
                                    Status = reader["status"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                                };
                            }
                        }
                    }
                }

                if (movie != null)
                {
                    AppUtils.WriteLine($"[ADO.NET] Found movie: {movie.Title}");
                }
                else
                {
                    AppUtils.WriteLine($"[ADO.NET] Movie with ID {movieId} not found.");
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[ADO.NET] Error getting movie by ID {movieId}");
            }
            return movie;
        }
        public List<FoodItemModel> GetAllFoodItems()
        {
            List<FoodItemModel> foodItems = new List<FoodItemModel>();
            AppUtils.WriteLine("[ADO.NET] Getting all food items.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT food_item_id, name, description, price, 
                                            image_url, category, is_available, 
                                            created_at, updated_at
                                     FROM FoodItems ORDER BY category, name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foodItems.Add(new FoodItemModel
                                {
                                    FoodItemId = Convert.ToInt32(reader["food_item_id"]),
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                    Price = Convert.ToDecimal(reader["price"]),
                                    ImageUrl = reader["image_url"] != DBNull.Value ? reader["image_url"].ToString() : null,
                                    Category = reader["category"] != DBNull.Value ? reader["category"].ToString() : null,
                                    IsAvailable = Convert.ToBoolean(reader["is_available"]),
                                    CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                    UpdatedAt = Convert.ToDateTime(reader["updated_at"])
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {foodItems.Count} food items.");
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllFoodItems (ADO): {ex.Message}\n{ex.StackTrace}"); }
            return foodItems;
        }
        public int AddFoodItem(FoodItemModel foodItem)
        {
            AppUtils.WriteLine($"[ADO.NET] Adding new food item: {foodItem.Name}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                        INSERT INTO FoodItems (name, description, price, image_url, category, is_available, created_at, updated_at)
                        VALUES (@Name, @Description, @Price, @ImageUrl, @Category, @IsAvailable, @CreatedAt, @UpdatedAt);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", foodItem.Name);
                        command.Parameters.AddWithValue("@Description", (object)foodItem.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", foodItem.Price);
                        command.Parameters.AddWithValue("@ImageUrl", (object)foodItem.ImageUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Category", (object)foodItem.Category ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsAvailable", foodItem.IsAvailable);
                        command.Parameters.AddWithValue("@CreatedAt", foodItem.CreatedAt == DateTime.MinValue ? DateTime.UtcNow : foodItem.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", foodItem.UpdatedAt == DateTime.MinValue ? DateTime.UtcNow : foodItem.UpdatedAt);

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int newItemId = Convert.ToInt32(result);
                            AppUtils.WriteLine($"[ADO.NET] Food item '{foodItem.Name}' added successfully with ID: {newItemId}.");
                            return newItemId;
                        }
                        AppUtils.WriteLine($"ERROR: [ADO.NET] Failed to add food item '{foodItem.Name}'. No ID returned.");
                        return 0;
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in AddFoodItem (ADO) for '{foodItem.Name}': {ex.Message}\n{ex.StackTrace}"); return 0; }
        }
        public bool UpdateFoodItem(FoodItemModel foodItem)
        {
            AppUtils.WriteLine($"[ADO.NET] Updating food item ID: {foodItem.FoodItemId} - {foodItem.Name}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                        UPDATE FoodItems SET 
                            name = @Name, description = @Description, price = @Price, 
                            image_url = @ImageUrl, category = @Category, 
                            is_available = @IsAvailable, updated_at = @UpdatedAt 
                        WHERE food_item_id = @FoodItemId;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FoodItemId", foodItem.FoodItemId);
                        command.Parameters.AddWithValue("@Name", foodItem.Name);
                        command.Parameters.AddWithValue("@Description", (object)foodItem.Description ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Price", foodItem.Price);
                        command.Parameters.AddWithValue("@ImageUrl", (object)foodItem.ImageUrl ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Category", (object)foodItem.Category ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsAvailable", foodItem.IsAvailable);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.UtcNow);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        AppUtils.WriteLine($"[ADO.NET] Food item ID {foodItem.FoodItemId} update. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in UpdateFoodItem (ADO) for ID {foodItem.FoodItemId}: {ex.Message}\n{ex.StackTrace}"); return false; }
        }
        public bool DeleteFoodItem(int foodItemId)
        {
            AppUtils.WriteLine($"[ADO.NET] Deleting food item ID: {foodItemId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Cân nhắc: Kiểm tra xem food item có đang được sử dụng trong OrderFoodItems không
                    string query = "DELETE FROM FoodItems WHERE food_item_id = @FoodItemId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FoodItemId", foodItemId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        AppUtils.WriteLine($"[ADO.NET] Food item ID {foodItemId} delete. Rows affected: {rowsAffected}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // Lỗi Foreign Key Constraint
            {
                AppUtils.WriteLine($"ERROR: [ADO.NET] Error deleting food item ID {foodItemId}: Item is in use (e.g., in Orders). {ex.Message}");
                MessageBox.Show("Không thể xóa sản phẩm này vì đang được sử dụng trong các đơn hàng.", "Lỗi Xóa Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in DeleteFoodItem (ADO) for ID {foodItemId}: {ex.Message}\n{ex.StackTrace}"); return false; }
        }
        public List<MovieModel> GetAllMoviesForScheduling()
        {
            List<MovieModel> movies = new List<MovieModel>();
            AppUtils.WriteLine("[ADO.NET] Getting all movies for scheduling.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT movie_id, title, duration_minutes, status 
                                     FROM Movies 
                                     WHERE status = 'active' OR status = 'upcoming'
                                     ORDER BY title ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movies.Add(new MovieModel 
                                {
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    Title = reader["title"].ToString(),
                                    DurationMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                    Status = reader["status"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllMoviesForScheduling (ADO.NET): {ex.Message}"); }
            return movies;
        }
        public List<CinemaRoomModel> GetAllActiveCinemaRooms()
        {
            List<CinemaRoomModel> rooms = new List<CinemaRoomModel>();
            AppUtils.WriteLine("[ADO.NET] Getting all active cinema rooms.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT room_id, room_name FROM CinemaRooms WHERE status = 'active' ORDER BY room_name ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rooms.Add(new CinemaRoomModel
                                {
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    RoomName = reader["room_name"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAllActiveCinemaRooms (ADO.NET): {ex.Message}"); }
            return rooms;
        }
        public List<ShowtimeModel> GetShowtimesForRoomOnDate(int roomId, DateTime date)
        {
            List<ShowtimeModel> showtimes = new List<ShowtimeModel>();
            AppUtils.WriteLine($"[ADO.NET] Getting showtimes for Room ID: {roomId} on Date: {date:yyyy-MM-dd}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT showtime_id, movie_id, room_id, start_time, end_time 
                                     FROM Showtimes 
                                     WHERE room_id = @RoomId AND CAST(start_time AS DATE) = @Date
                                     ORDER BY start_time ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomId", roomId);
                        command.Parameters.AddWithValue("@Date", date.Date); // Chỉ so sánh phần ngày
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                showtimes.Add(new ShowtimeModel
                                {
                                    ShowtimeId = Convert.ToInt32(reader["showtime_id"]),
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    StartTime = Convert.ToDateTime(reader["start_time"]),
                                    EndTime = Convert.ToDateTime(reader["end_time"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimesForRoomOnDate (ADO.NET): {ex.Message}"); }
            return showtimes;
        }
        public bool AddShowtime(ShowtimeModel showtime)
        {
            AppUtils.WriteLine($"[ADO.NET] Adding new showtime for Movie ID: {showtime.MovieId}, Room ID: {showtime.RoomId} at {showtime.StartTime}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                        INSERT INTO Showtimes (movie_id, room_id, start_time, end_time, created_at, updated_at)
                        VALUES (@MovieId, @RoomId, @StartTime, @EndTime, @CreatedAt, @UpdatedAt);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", showtime.MovieId);
                        command.Parameters.AddWithValue("@RoomId", showtime.RoomId);
                        command.Parameters.AddWithValue("@StartTime", showtime.StartTime);
                        command.Parameters.AddWithValue("@EndTime", showtime.EndTime);
                        command.Parameters.AddWithValue("@CreatedAt", showtime.CreatedAt == DateTime.MinValue ? DateTime.UtcNow : showtime.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", showtime.UpdatedAt == DateTime.MinValue ? DateTime.UtcNow : showtime.UpdatedAt);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in AddShowtime (ADO.NET): {ex.Message}");
                return false;
            }
        }
        public List<FullShowtimeInfoModel> GetFullShowtimesByDate(DateTime date)
        {
            List<FullShowtimeInfoModel> showtimes = new List<FullShowtimeInfoModel>();
            AppUtils.WriteLine($"[ADO.NET] Getting full showtimes for date: {date:yyyy-MM-dd}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                        SELECT 
                            s.showtime_id, s.start_time, s.end_time,
                            s.movie_id, m.title AS movie_title, m.duration_minutes AS movie_duration_minutes, 
                            m.poster_image_url AS movie_poster_image_url, m.genre AS movie_genre, m.rating_details AS movie_rating_details,
                            s.room_id, cr.room_name
                        FROM Showtimes s
                        JOIN Movies m ON s.movie_id = m.movie_id
                        JOIN CinemaRooms cr ON s.room_id = cr.room_id
                        WHERE CAST(s.start_time AS DATE) = @SelectedDate
                        ORDER BY s.start_time ASC, cr.room_name ASC;
                    ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SelectedDate", date.Date);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                showtimes.Add(new FullShowtimeInfoModel
                                {
                                    ShowtimeId = Convert.ToInt32(reader["showtime_id"]),
                                    StartTime = Convert.ToDateTime(reader["start_time"]),
                                    EndTime = Convert.ToDateTime(reader["end_time"]),
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    MovieTitle = reader["movie_title"].ToString(),
                                    MovieDurationMinutes = Convert.ToInt32(reader["movie_duration_minutes"]),
                                    MoviePosterImageUrl = reader["movie_poster_image_url"] != DBNull.Value ? reader["movie_poster_image_url"].ToString() : null,
                                    MovieGenre = reader["movie_genre"] != DBNull.Value ? reader["movie_genre"].ToString() : null,
                                    MovieRatingDetails = reader["movie_rating_details"] != DBNull.Value ? reader["movie_rating_details"].ToString() : null,
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    RoomName = reader["room_name"].ToString()
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {showtimes.Count} showtimes for {date:yyyy-MM-dd}.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in GetFullShowtimesByDate (ADO.NET): {ex.Message}");
            }
            return showtimes;
        }
        public ShowtimeModel GetShowtimeById(int showtimeId)
        {
            ShowtimeModel showtime = null;
            AppUtils.WriteLine($"[ADO.NET] Getting showtime by ID: {showtimeId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT showtime_id, movie_id, room_id, start_time, end_time FROM Showtimes WHERE showtime_id = @ShowtimeId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShowtimeId", showtimeId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                showtime = new ShowtimeModel
                                {
                                    ShowtimeId = Convert.ToInt32(reader["showtime_id"]),
                                    MovieId = Convert.ToInt32(reader["movie_id"]),
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    StartTime = Convert.ToDateTime(reader["start_time"]),
                                    EndTime = Convert.ToDateTime(reader["end_time"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimeById (ADO.NET): {ex.Message}"); }
            return showtime;
        }
        public List<ShowtimeBookingInfoModel> GetShowtimesForBooking(int movieId, DateTime date)
        {
            List<ShowtimeBookingInfoModel> showtimes = new List<ShowtimeBookingInfoModel>();
            AppUtils.WriteLine($"[ADO.NET] Getting showtimes for booking for Movie ID: {movieId} on Date: {date:yyyy-MM-dd}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                SELECT 
                    s.showtime_id, s.start_time, s.end_time, s.room_id,
                    cr.room_name,
                    (SELECT COUNT(*) FROM Seats se WHERE se.room_id = s.room_id AND se.is_active = 1) AS TotalSeatsInRoom,
                    (SELECT COUNT(*) FROM Tickets t WHERE t.showtime_id = s.showtime_id AND t.status <> 'cancelled') AS BookedSeatsCount
                FROM Showtimes s
                JOIN CinemaRooms cr ON s.room_id = cr.room_id
                WHERE s.movie_id = @MovieId AND CAST(s.start_time AS DATE) = @SelectedDate AND s.start_time > GETDATE()
                ORDER BY s.start_time ASC, cr.room_name ASC;
            ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        command.Parameters.AddWithValue("@SelectedDate", date.Date);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                showtimes.Add(new ShowtimeBookingInfoModel
                                {
                                    ShowtimeId = Convert.ToInt32(reader["showtime_id"]),
                                    StartTime = Convert.ToDateTime(reader["start_time"]),
                                    EndTime = Convert.ToDateTime(reader["end_time"]),
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    RoomName = reader["room_name"].ToString(),
                                    TotalSeatsInRoom = Convert.ToInt32(reader["TotalSeatsInRoom"]),
                                    BookedSeatsCount = Convert.ToInt32(reader["BookedSeatsCount"])
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {showtimes.Count} showtimes for booking on {date:yyyy-MM-dd}.");
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetShowtimesForBooking (ADO.NET): {ex.Message}"); }
            return showtimes;
        }
        public List<int> GetBookedSeatIdsForShowtime(int showtimeId)
        {
            List<int> bookedSeatIds = new List<int>();
            AppUtils.WriteLine($"[ADO.NET] Getting booked seats for Showtime ID: {showtimeId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT seat_id FROM Tickets WHERE showtime_id = @ShowtimeId AND status <> 'cancelled'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShowtimeId", showtimeId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookedSeatIds.Add(Convert.ToInt32(reader["seat_id"]));
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {bookedSeatIds.Count} booked seats for Showtime ID: {showtimeId}.");
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetBookedSeatIdsForShowtime (ADO.NET): {ex.Message}"); }
            return bookedSeatIds;
        }
        public List<SeatModel> GetSeatsByRoomId(int roomId)
        {
            List<SeatModel> seats = new List<SeatModel>();
            AppUtils.WriteLine($"[ADO.NET] Getting seats for Room ID: {roomId}");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT seat_id, room_id, seat_type_id, row_identifier, 
                                            seat_number_in_row, is_active 
                                     FROM Seats 
                                     WHERE room_id = @RoomId
                                     ORDER BY row_identifier ASC, TRY_CAST(seat_number_in_row AS INT) ASC, seat_number_in_row ASC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomId", roomId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                seats.Add(new SeatModel
                                {
                                    SeatId = Convert.ToInt32(reader["seat_id"]),
                                    RoomId = Convert.ToInt32(reader["room_id"]),
                                    SeatTypeId = Convert.ToInt32(reader["seat_type_id"]),
                                    RowIdentifier = reader["row_identifier"].ToString(),
                                    SeatNumberInRow = reader["seat_number_in_row"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["is_active"])
                                });
                            }
                        }
                    }
                }
                AppUtils.WriteLine($"[ADO.NET] Found {seats.Count} seats for Room ID: {roomId}.");
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in GetSeatsByRoomId (ADO.NET) for RoomID {roomId}: {ex.GetType().FullName} - {ex.Message}");
                AppUtils.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            return seats;
        }
        public List<FoodItemModel> GetAvailableFoodItems()
        {
            List<FoodItemModel> foodItems = new List<FoodItemModel>();
            AppUtils.WriteLine("[ADO.NET] Getting available food items.");
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT food_item_id, name, description, price, image_url, category, is_available FROM FoodItems WHERE is_available = 1 ORDER BY category, name";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foodItems.Add(new FoodItemModel
                                {
                                    FoodItemId = Convert.ToInt32(reader["food_item_id"]),
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"] != DBNull.Value ? reader["description"].ToString() : null,
                                    Price = Convert.ToDecimal(reader["price"]),
                                    ImageUrl = reader["image_url"] != DBNull.Value ? reader["image_url"].ToString() : null,
                                    Category = reader["category"] != DBNull.Value ? reader["category"].ToString() : null,
                                    IsAvailable = Convert.ToBoolean(reader["is_available"])
                                    // CreatedAt, UpdatedAt không cần thiết cho việc hiển thị này
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { AppUtils.WriteLine($"EXCEPTION in GetAvailableFoodItems (ADO.NET): {ex.Message}"); }
            return foodItems;
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
                AppUtils.WriteLine("ERROR: [ADO.NET CreateFullOrder] Invalid input parameters.");
                return null;
            }

            AppUtils.WriteLine($"[ADO.NET] Creating full order for UserID: {currentUser.UserId}, ShowtimeID: {selectedShowtime.ShowtimeId}");
            SqlTransaction transaction = null;
            OrderConfirmationModel confirmation = null;

            decimal subtotalTickets = 0;
            foreach (var seat in selectedSeats)
            {
                var seatType = allSeatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                subtotalTickets += seatType?.DefaultPrice ?? 0;
            }
            decimal subtotalFood = selectedFoodItems?.Sum(f => f.Subtotal) ?? 0;
            decimal totalAmount = subtotalTickets + subtotalFood;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // 1. Tạo OrderModel
                    OrderModel newOrder = new OrderModel
                    {
                        UserId = currentUser.UserId,
                        OrderDateTime = DateTime.UtcNow,
                        SubtotalTickets = subtotalTickets,
                        SubtotalFood = subtotalFood,
                        PromotionId = null, // Chưa có logic khuyến mãi
                        DiscountAmount = 0,
                        AmountBeforeVat = totalAmount,
                        VatPercentage = 0,
                        VatAmount = 0,
                        TotalAmount = totalAmount,
                        Status = "paid",
                        PaymentMethod = "Online",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    string orderQuery = @"
                        INSERT INTO Orders (user_id, order_datetime, subtotal_tickets, subtotal_food, total_amount, status, payment_method, created_at, updated_at)
                        VALUES (@UserId, @OrderDateTime, @SubtotalTickets, @SubtotalFood, @TotalAmount, @Status, @PaymentMethod, @CreatedAt, @UpdatedAt);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int orderId;
                    using (SqlCommand orderCommand = new SqlCommand(orderQuery, connection, transaction))
                    {
                        orderCommand.Parameters.AddWithValue("@UserId", newOrder.UserId);
                        orderCommand.Parameters.AddWithValue("@OrderDateTime", newOrder.OrderDateTime);
                        orderCommand.Parameters.AddWithValue("@SubtotalTickets", newOrder.SubtotalTickets);
                        orderCommand.Parameters.AddWithValue("@SubtotalFood", newOrder.SubtotalFood);
                        orderCommand.Parameters.AddWithValue("@TotalAmount", newOrder.TotalAmount);
                        orderCommand.Parameters.AddWithValue("@Status", newOrder.Status);
                        orderCommand.Parameters.AddWithValue("@PaymentMethod", (object)newOrder.PaymentMethod ?? DBNull.Value);
                        orderCommand.Parameters.AddWithValue("@CreatedAt", newOrder.CreatedAt);
                        orderCommand.Parameters.AddWithValue("@UpdatedAt", newOrder.UpdatedAt);
                        orderId = (int)orderCommand.ExecuteScalar();
                    }
                    newOrder.OrderId = orderId; // Cập nhật OrderId cho model
                    AppUtils.WriteLine($"[ADO.NET] Order created with ID: {orderId}");

                    // 2. Tạo Tickets
                    List<string> ticketCodesGenerated = new List<string>();
                    string ticketQuery = @"
                        INSERT INTO Tickets (order_id, showtime_id, seat_id, price_at_purchase, ticket_code, status, created_at, updated_at)
                        VALUES (@OrderId, @ShowtimeId, @SeatId, @PriceAtPurchase, @TicketCode, @Status, @CreatedAt, @UpdatedAt);";

                    foreach (var seat in selectedSeats)
                    {
                        var seatType = allSeatTypes.FirstOrDefault(st => st.SeatTypeId == seat.SeatTypeId);
                        decimal price = seatType?.DefaultPrice ?? 0;
                        string ticketCode = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(); // Mã vé ngẫu nhiên

                        using (SqlCommand ticketCommand = new SqlCommand(ticketQuery, connection, transaction))
                        {
                            ticketCommand.Parameters.AddWithValue("@OrderId", orderId);
                            ticketCommand.Parameters.AddWithValue("@ShowtimeId", selectedShowtime.ShowtimeId);
                            ticketCommand.Parameters.AddWithValue("@SeatId", seat.SeatId);
                            ticketCommand.Parameters.AddWithValue("@PriceAtPurchase", price);
                            ticketCommand.Parameters.AddWithValue("@TicketCode", ticketCode);
                            ticketCommand.Parameters.AddWithValue("@Status", "booked");
                            ticketCommand.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                            ticketCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.UtcNow);
                            ticketCommand.ExecuteNonQuery();
                            ticketCodesGenerated.Add(ticketCode);
                        }
                    }
                    AppUtils.WriteLine($"[ADO.NET] Added {selectedSeats.Count} tickets for Order ID: {orderId}");

                    // 3. Tạo OrderFoodItems (nếu có)
                    if (selectedFoodItems != null && selectedFoodItems.Any())
                    {
                        string foodQuery = @"
                            INSERT INTO OrderFoodItems (order_id, food_item_id, quantity, price_per_item_at_purchase, subtotal_for_item, created_at)
                            VALUES (@OrderId, @FoodItemId, @Quantity, @PricePerItem, @Subtotal, @CreatedAt);";
                        foreach (var foodData in selectedFoodItems)
                        {
                            using (SqlCommand foodCommand = new SqlCommand(foodQuery, connection, transaction))
                            {
                                foodCommand.Parameters.AddWithValue("@OrderId", orderId);
                                foodCommand.Parameters.AddWithValue("@FoodItemId", foodData.FoodItemId);
                                foodCommand.Parameters.AddWithValue("@Quantity", foodData.Quantity);
                                foodCommand.Parameters.AddWithValue("@PricePerItem", foodData.PricePerItem);
                                foodCommand.Parameters.AddWithValue("@Subtotal", foodData.Subtotal);
                                foodCommand.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                                foodCommand.ExecuteNonQuery();
                            }
                        }
                        AppUtils.WriteLine($"[ADO.NET] Added {selectedFoodItems.Count} types of food items for Order ID: {orderId}");
                    }

                    transaction.Commit();
                    AppUtils.WriteLine($"[ADO.NET] Full order transaction committed for Order ID: {orderId}");

                    MovieModel movieDetails = GetMovieById(selectedShowtime.MovieId);
                    confirmation = new OrderConfirmationModel
                    {
                        OrderId = orderId,
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
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"EXCEPTION in CreateFullOrder (ADO.NET): {ex.Message}\nStackTrace: {ex.StackTrace}");
                try { transaction?.Rollback(); AppUtils.WriteLine("[ADO.NET] Transaction rolled back."); }
                catch (Exception rbEx) { AppUtils.WriteLine($"EXCEPTION during ADO.NET transaction rollback: {rbEx.Message}"); }
                return null;
            }
            return confirmation;
        }
    }
}
