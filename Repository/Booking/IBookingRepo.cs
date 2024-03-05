using JourneyJoy.Database;
using JourneyJoy.Models;
using System;

namespace JourneyJoy.Repository.Booking
{
    public class BookingRepo : IBookingRepo
    {
        DatabaseAccessObject _dao;
        public BookingRepo()
        {
            _dao = new DatabaseAccessObject();
        }

        public CommonModel BookVehicle(string vid)
        {
            throw new NotImplementedException();
        }
    }
    #region INTERFACE
    public interface IBookingRepo
    {
        CommonModel BookVehicle(string vid);
    }
    #endregion
}
