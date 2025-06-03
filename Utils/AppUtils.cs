using CinemaApplication.Enums;
using CinemaApplication.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Utils
{
    public static class AppUtils
    {
        private static UserModel LoggedInUser;
        public static void SetCurrentUser(UserModel user)
        {
            LoggedInUser = user;
        }

        public static UserModel GetLoggedInUserInfo()
        {
            return LoggedInUser;
        }
        public static string GetAppProperty(AppConfigPropertiesEnum propertyName)
        {
            try
            {
                switch (propertyName)
                {
                    case AppConfigPropertiesEnum.DB_CONNECTION_STRING:
                        return Properties.Resources.DB_CONNECTION_STRING;

                    // add more case:
                    // case AppConfigProperties.DEFAULT_PAGE_SIZE:
                    //     return Properties.Settings.Default.DEFAULT_PAGE_SIZE.ToString();

                    default:
                        AppUtils.WriteLine($"[AppConfigUtils] Warning: Property '{propertyName}' not defined in GetAppProperty method.");
                        return null;
                }
            }
            catch (Exception ex)
            {
                AppUtils.WriteLine($"[AppConfigUtils] Error retrieving property '{propertyName}': {ex.Message}");
                return null;
            }
        }
        public static Color GetColorForSeatType(string seatTypeName)
        {
            if (string.IsNullOrEmpty(seatTypeName)) return Color.LightGray;

            switch (seatTypeName.ToLower())
            {
                case "standard":
                    return Color.Green;
                case "vip":
                    return Color.Orange;
                case "couple": // Ghế đôi có thể cần xử lý đặc biệt về kích thước (ví dụ: chiếm 2 "ô")
                    return Color.HotPink;
                default:
                    return Color.LightGray; // Màu cho các loại ghế khác
            }
        }
        [Conditional("DEBUG")]
        public static void WriteLine(string format, params object[] args)
        {
            if (args == null)
            {
                Debug.WriteLine(format); 
            }
            else
            {
                Debug.WriteLine(string.Format(format, args));
            }
        }
    }
}
