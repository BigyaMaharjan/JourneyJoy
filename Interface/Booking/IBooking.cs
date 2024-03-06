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

        public CommonModel BookVehicle(string vid)
        {
           return _Repo.BookVehicle(vid);
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
    }
    #endregion
}