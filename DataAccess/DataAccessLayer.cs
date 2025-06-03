using CinemaApplication.Enums;
using CinemaApplication.Interfaces;
using CinemaApplication.Models;
using CinemaApplication.Utils;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaApplication.DataAccess
{
    public class DataAccessLayer : IDataAccess
    {
        private IDataAccess _dataAccessor;
        public DataAccessLayerVersionEnum CurrentVersion { get; }

        public DataAccessLayer(DataAccessLayerVersionEnum version)
        {
            CurrentVersion = version;
            string connectionString = AppUtils.GetAppProperty(AppConfigPropertiesEnum.DB_CONNECTION_STRING);
            AppUtils.WriteLine("new DataAccessLayer", connectionString);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string is required.");
            }

            switch (version)
            {
                case DataAccessLayerVersionEnum.ADO_NET:
                    _dataAccessor = new DataAccessADO(connectionString);
                    AppUtils.WriteLine("DataAccessLayer initialized with ADO.NET.");
                    break;

                case DataAccessLayerVersionEnum.ENTITY_FRAMEWORK:
                    _dataAccessor = new DataAccessEntityFramework(connectionString);
                    AppUtils.WriteLine("DataAccessLayer initialized with Entity Framework.");
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unsupported data access layer version specified.");
            }
        }
        public void SetDataAccessLayerVersion(DataAccessLayerVersionEnum version)
        {
            if (version == CurrentVersion)
            {
                //AppUtils.WriteLine("Data access layer version is already set to: " + version);
                return;
            }
            else if (_dataAccessor == null)
            {
                AppUtils.WriteLine("Empty data access layer!");
                return;
            }
            else
            {
                string connectionString = AppUtils.GetAppProperty(AppConfigPropertiesEnum.DB_CONNECTION_STRING);
                switch (version)
                {
                    case DataAccessLayerVersionEnum.ADO_NET:
                        _dataAccessor = new DataAccessADO(connectionString);
                        AppUtils.WriteLine("DataAccessLayer initialized with ADO.NET.");
                        break;
                    case DataAccessLayerVersionEnum.ENTITY_FRAMEWORK:
                        _dataAccessor = new DataAccessEntityFramework(connectionString);
                        AppUtils.WriteLine("DataAccessLayer initialized with Entity Framework.");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(version), "Unsupported data access layer version specified.");
                }
            }
        }
        public bool RegisterUser(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return _dataAccessor.RegisterUser(user);
        }

        public UserModel AuthenticateUser(string username, string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(plainTextPassword))
            {
                return null;
            }
            return _dataAccessor.AuthenticateUser(username, plainTextPassword);
        }

        public List<MovieModel> GetMoviesByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return null;
            }
            return _dataAccessor.GetMoviesByStatus(status);
        }

        public List<SeatTypeModel> GetAllSeatTypes()
        {
            AppUtils.WriteLine($"[DataAccessLayer] Calling GetAllSeatTypes via {CurrentVersion}");
            return _dataAccessor.GetAllSeatTypes();
        }

        public int AddCinemaRoom(CinemaRoomModel room)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            AppUtils.WriteLine($"[DataAccessLayer] Calling AddCinemaRoom for '{room.RoomName}' via {CurrentVersion}");
            return _dataAccessor.AddCinemaRoom(room);
        }

        public bool AddSeats(List<SeatModel> seats)
        {
            if (seats == null || !seats.Any())
            {
                AppUtils.WriteLine("[DataAccessLayer] AddSeats called with null or empty list. No action taken.");
                return true;
            }
            AppUtils.WriteLine($"[DataAccessLayer] Calling AddSeats for {seats.Count} seats via {CurrentVersion}");
            return _dataAccessor.AddSeats(seats);
        }
        public List<CinemaRoomStatsModel> GetAllCinemaRoomsWithStats()
        {
            return _dataAccessor.GetAllCinemaRoomsWithStats();
        }
        public List<MovieModel> GetAllMovies()
        {
            return _dataAccessor.GetAllMovies();
        }

        public int AddMovie(MovieModel movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            return _dataAccessor.AddMovie(movie);
        }

        public bool UpdateMovie(MovieModel movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));
            return _dataAccessor.UpdateMovie(movie);
        }

        public bool DeleteMovie(int movieId)
        {
            if (movieId <= 0) throw new ArgumentException("Movie ID must be greater than zero.", nameof(movieId));
            return _dataAccessor.DeleteMovie(movieId);
        }

        public MovieModel GetMovieById(int movieId)
        {
            return _dataAccessor.GetMovieById(movieId);
        }

        public List<FoodItemModel> GetAllFoodItems()
        {
            return _dataAccessor.GetAllFoodItems();
        }

        public int AddFoodItem(FoodItemModel foodItem)
        {
            return _dataAccessor.AddFoodItem(foodItem);
        }

        public bool UpdateFoodItem(FoodItemModel foodItem)
        {
            return _dataAccessor.UpdateFoodItem(foodItem);
        }

        public bool DeleteFoodItem(int foodItemId)
        {
            return _dataAccessor.DeleteFoodItem(foodItemId);
        }

        public List<MovieModel> GetAllMoviesForScheduling()
        {
            return _dataAccessor.GetAllMoviesForScheduling();
        }

        public List<CinemaRoomModel> GetAllActiveCinemaRooms()
        {
            return _dataAccessor.GetAllActiveCinemaRooms();
        }

        public List<ShowtimeModel> GetShowtimesForRoomOnDate(int roomId, DateTime date)
        {
            return _dataAccessor.GetShowtimesForRoomOnDate(roomId, date);
        }

        public bool AddShowtime(ShowtimeModel showtime)
        {
            return _dataAccessor.AddShowtime(showtime);
        }

        public List<FullShowtimeInfoModel> GetFullShowtimesByDate(DateTime date)
        {
            return _dataAccessor.GetFullShowtimesByDate(date);
        }

        public List<ShowtimeBookingInfoModel> GetShowtimesForBooking(int movieId, DateTime date)
        {
            return _dataAccessor.GetShowtimesForBooking(movieId, date);
        }

        public List<SeatModel> GetSeatsByRoomId(int roomId)
        {
            return _dataAccessor.GetSeatsByRoomId(roomId);
        }

        public List<int> GetBookedSeatIdsForShowtime(int showtimeId)
        {
            return _dataAccessor.GetBookedSeatIdsForShowtime(showtimeId);
        }

        public ShowtimeModel GetShowtimeById(int showtimeId)
        {
            return _dataAccessor.GetShowtimeById(showtimeId);
        }

        public List<FoodItemModel> GetAvailableFoodItems()
        {
            return _dataAccessor.GetAvailableFoodItems();
        }

        public OrderConfirmationModel CreateFullOrder(UserModel currentUser, ShowtimeBookingInfoModel selectedShowtime, List<SeatModel> selectedSeats, List<OrderFoodItemData> selectedFoodItems, List<SeatTypeModel> allSeatTypes)
        {
            return _dataAccessor.CreateFullOrder(currentUser, selectedShowtime, selectedSeats, selectedFoodItems, allSeatTypes);
        }
    }
}
