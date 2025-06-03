using CinemaApplication.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Interfaces
{
    public interface IDataAccess
    {
        bool RegisterUser(UserModel user);
        UserModel AuthenticateUser(string username, string password);
        List<MovieModel> GetMoviesByStatus(string status);
        List<SeatTypeModel> GetAllSeatTypes();
        int AddCinemaRoom(CinemaRoomModel room);
        bool AddSeats(List<SeatModel> seats);
        List<CinemaRoomStatsModel> GetAllCinemaRoomsWithStats();
        List<MovieModel> GetAllMovies();
        MovieModel GetMovieById(int movieId);
        int AddMovie(MovieModel movie);
        bool UpdateMovie(MovieModel movie);
        bool DeleteMovie(int movieId);
        List<FoodItemModel> GetAllFoodItems();
        int AddFoodItem(FoodItemModel foodItem);
        bool UpdateFoodItem(FoodItemModel foodItem);
        bool DeleteFoodItem(int foodItemId);
        List<MovieModel> GetAllMoviesForScheduling();
        List<CinemaRoomModel> GetAllActiveCinemaRooms(); // Lấy danh sách phòng đang hoạt động
        List<ShowtimeModel> GetShowtimesForRoomOnDate(int roomId, DateTime date); // Lấy suất chiếu trong phòng vào ngày cụ thể
        bool AddShowtime(ShowtimeModel showtime); // Thêm suất chiếu mới
        List<FullShowtimeInfoModel> GetFullShowtimesByDate(DateTime date);

        List<ShowtimeBookingInfoModel> GetShowtimesForBooking(int movieId, DateTime date); // Lấy suất chiếu kèm thông tin ghế
        List<SeatModel> GetSeatsByRoomId(int roomId);
        List<int> GetBookedSeatIdsForShowtime(int showtimeId); 
        ShowtimeModel GetShowtimeById(int showtimeId);
        List<FoodItemModel> GetAvailableFoodItems();
        OrderConfirmationModel CreateFullOrder(
            UserModel currentUser,
            ShowtimeBookingInfoModel selectedShowtime,
            List<SeatModel> selectedSeats,
            List<OrderFoodItemData> selectedFoodItems,
            List<SeatTypeModel> allSeatTypes
        );
    }
}
