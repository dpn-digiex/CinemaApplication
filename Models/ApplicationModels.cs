using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class MovieModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; } 
        public int DurationMinutes { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PosterImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public string RatingDetails { get; set; } // Ví dụ: 'P', 'C13', 'C16', 'C18'
        public string Status { get; set; } // Ví dụ: 'active', 'inactive', 'upcoming'
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class SeatTypeModel
    {
        public int SeatTypeId { get; set; }
        public string TypeName { get; set; } // Ví dụ: 'Standard', 'VIP', 'Couple'
        public decimal DefaultPrice { get; set; }
        public string Description { get; set; }
        public string DisplayColorHex { get; set; }

        // Navigation Property: Một loại ghế có thể được sử dụng cho nhiều ghế
        public virtual ICollection<SeatModel> Seats { get; set; } = new List<SeatModel>();
    }

    public class CinemaRoomModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; } // Ví dụ: "Room 1", "Gold Hall"
        public string RoomLayoutDescription { get; set; } // Mô tả sơ đồ hoặc đặc điểm phòng
        public string Status { get; set; } // Ví dụ: 'active', 'under_maintenance'
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<SeatModel> Seats { get; set; } = new List<SeatModel>();
    }

    public class SeatModel
    {
        public int SeatId { get; set; }
        public int RoomId { get; set; } // Foreign Key đến CinemaRoomModel
        public int SeatTypeId { get; set; } // Foreign Key đến SeatTypeModel
        public string RowIdentifier { get; set; } // Ví dụ: 'A', 'B'
        public string SeatNumberInRow { get; set; } // Ví dụ: '1', '12'
        public bool IsActive { get; set; } = true; // Mặc định là ghế sử dụng được

        // Navigation Property: Mỗi ghế thuộc về một loại ghế
        public virtual SeatTypeModel SeatType { get; set; }
        // Navigation Property: Mỗi ghế thuộc về một phòng chiếu
        public virtual CinemaRoomModel CinemaRoom { get; set; }

    }

    public class ShowtimeModel
    {
        public int ShowtimeId { get; set; }
        public int MovieId { get; set; } // Foreign Key đến MovieModel
        public int RoomId { get; set; } // Foreign Key đến CinemaRoomModel
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual MovieModel Movie { get; set; }
        public virtual CinemaRoomModel CinemaRoom { get; set; }
        public virtual ICollection<TicketModel> Tickets { get; set; } = new List<TicketModel>();
    }

    public class OrderModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; } // Foreign Key đến UserModel
        public DateTime OrderDateTime { get; set; } = DateTime.UtcNow;
        public decimal SubtotalTickets { get; set; } = 0;
        public decimal SubtotalFood { get; set; } = 0;
        public int? PromotionId { get; set; } // Foreign Key đến PromotionModel, có thể null
        public decimal DiscountAmount { get; set; } = 0;
        public decimal AmountBeforeVat { get; set; } = 0;
        public decimal VatPercentage { get; set; } = 8.00m; // Ví dụ 8% VAT
        public decimal VatAmount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public string Status { get; set; } // Ví dụ: 'pending_payment', 'paid', 'cancelled'
        public string PaymentMethod { get; set; }
        public string PaymentTransactionId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }

    public class TicketModel
    {
        public int TicketId { get; set; }
        public int OrderId { get; set; } // Foreign Key đến OrderModel
        public int ShowtimeId { get; set; } // Foreign Key đến ShowtimeModel
        public int SeatId { get; set; } // Foreign Key đến SeatModel
        public decimal PriceAtPurchase { get; set; }
        public string TicketCode { get; set; } // Mã vé duy nhất (ví dụ cho QR code)
        public string Status { get; set; } // Ví dụ: 'booked', 'cancelled', 'checked_in'
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class FoodItemModel
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; } // Ví dụ: 'Popcorn', 'Drink', 'Combo'
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class OrderFoodItemModel
    {
        public int OrderFoodItemId { get; set; } // Khóa chính của bảng này
        public int OrderId { get; set; } // Foreign Key đến OrderModel
        public int FoodItemId { get; set; } // Foreign Key đến FoodItemModel
        public int Quantity { get; set; } = 1;
        public decimal PricePerItemAtPurchase { get; set; } 
        public decimal SubtotalForItem { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

    public class PromotionModel
    {
        public int PromotionId { get; set; }
        public string Code { get; set; } // Mã khuyến mãi duy nhất
        public string Description { get; set; }
        public string DiscountType { get; set; } // Ví dụ: 'percentage', 'fixed_amount'
        public decimal DiscountValue { get; set; } // Giá trị chiết khấu (số tiền hoặc %)
        public decimal? MaxDiscountAmount { get; set; } // Số tiền giảm giá tối đa nếu là 'percentage'
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? UsageLimitPerUser { get; set; } // Số lần một người dùng có thể sử dụng
        public int? TotalUsageLimit { get; set; } // Tổng số lần khuyến mãi này có thể được sử dụng
        public decimal? MinOrderValue { get; set; } // Giá trị đơn hàng tối thiểu để áp dụng
        public string ApplicableTo { get; set; } // Ví dụ: 'all', 'tickets_only', 'food_only'
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class CinemaRoomStatsModel
    {
        public int STT { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalSeats { get; set; }
        public int StandardSeats { get; set; }
        public int VipSeats { get; set; }
        public int CoupleSeats { get; set; }
        // Bạn có thể thêm các loại ghế khác nếu cần
    }
    public class FullShowtimeInfoModel
    {
        public int ShowtimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int MovieDurationMinutes { get; set; }
        public string MoviePosterImageUrl { get; set; }
        public string MovieGenre { get; set; }
        public string MovieRatingDetails { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public string TimeSlotDisplay => $"{StartTime:HH:mm} - {EndTime:HH:mm}";
    }

    public class ShowtimeBookingInfoModel
    {
        public int ShowtimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MovieId { get; set; } 
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public int TotalSeatsInRoom { get; set; }
        public int BookedSeatsCount { get; set; }
        public int AvailableSeats => TotalSeatsInRoom - BookedSeatsCount;
        public string TimeSlotDisplay => $"{StartTime:HH:mm} - {EndTime:HH:mm}";
        public string AvailabilityDisplay => $"Còn {AvailableSeats}/{TotalSeatsInRoom} ghế";
    }
    public class OrderFoodItemData
    {
        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal Subtotal => Quantity * PricePerItem;
    }
    public class OrderConfirmationModel
    {
        public int OrderId { get; set; }
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShowtimeStartTime { get; set; }
        public List<string> SeatCodes { get; set; } // Ví dụ: "A1", "B2"
        public List<string> TicketCodes { get; set; } // Mã vé được tạo
        public decimal TotalAmountPaid { get; set; }
        public List<string> FoodItemsSummary { get; set; } // Ví dụ: "Bắp Lớn x1: 55,000đ"
        public DateTime OrderDateTime { get; set; }

        public OrderConfirmationModel()
        {
            SeatCodes = new List<string>();
            TicketCodes = new List<string>();
            FoodItemsSummary = new List<string>();
        }
    }
}
