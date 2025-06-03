using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApplication.Enums
{
    public enum DataAccessLayerVersionEnum
    {
        ADO_NET,
        ENTITY_FRAMEWORK
    }
    public enum UserRoleEnum
    {
        user,
        admin
    }
    public enum AppConfigPropertiesEnum
    {
        DB_CONNECTION_STRING
        // add more...
        // DEFAULT_PAGE_SIZE,
        // API_ENDPOINT_URL
    }

    public enum MovieStatusEnum
    {
        active,
        upcoming,
    }
    public enum CustomerChildFormEnum
    {
        MovieShowingForm,
        MovieUpcomingForm,
        MyTicketForm
        // more forms...
    }

    public enum AdminChildFormEnum
    {
        MovieShowingForm,
        MovieUpcomingForm,
        AddCinemaRoomForm,
        ListCinemaRoomForm,
        ManageMovieForm,
        ManageFoodForm,
        AddMovieShowtimeForm,
        ShowtimesMovieForm,
        StatisticalForm
        // more forms...
    }
    public enum SeatTypeEnum
    {
       Standard,
       Vip,
       Couple
    }
    public enum StatusGeneralEnum
    {
        active,
        inactive
    }
}
