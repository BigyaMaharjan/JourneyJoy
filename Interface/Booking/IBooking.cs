using JourneyJoy.Models;
using JourneyJoy.Repository.Booking;
using System;

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
    }

    #region INTERFACE
    public interface IBooking
    {
        CommonModel BookVehicle(string vid);
    }
    #endregion
}