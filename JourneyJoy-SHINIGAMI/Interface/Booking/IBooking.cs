using JourneyJoy.Models;
using JourneyJoy.Repository.Booking;

namespace JourneyJoy.Interface.Booking
{
    public class Booking : IBooking
    {
        IBookingRepo _Repo;
        public Booking(BookingRepo repo)
        {
            _Repo = repo;
        }

        public CommonModel AddNewVehicles(LogInResponseModel model)
        {
            return _Repo.AddNewVehicles(model);
        }

        public CommonModel BookVehicle(string vid)
        {
           return _Repo.BookVehicle(vid);
        }

        public CommonModel CancellBooking(string BID, string VID)
        {
            return _Repo.CancellBooking(BID,VID);
        }

        public CommonModel GetUserBookings(string UID)
        {
            return _Repo.GetUserBookings(UID);
        }

        public CommonModel SaveBooking(BookingModel model)
        {
            return _Repo.SaveBooking(model);
        }
    }

    #region INTERFACE
    public interface IBooking
    {
        CommonModel BookVehicle(string vid);
        CommonModel SaveBooking(BookingModel model);
        CommonModel GetUserBookings(string UID);
        CommonModel CancellBooking(string BID, string VID);

        #region Vendor Add Vehicles
        CommonModel AddNewVehicles(LogInResponseModel model);
        #endregion
    }
    #endregion
}