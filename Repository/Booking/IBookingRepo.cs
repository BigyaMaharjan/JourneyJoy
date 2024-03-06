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

        public CommonModel SaveBooking(BookingModel model)
        {
            var SQL = "Exec sp_Booking_Vehicle  @Flag='bv'"; // book vehicle
            SQL += ",@Username=" + _dao.FilterString(model.Username);
            SQL += ",@Email=" + _dao.FilterString(model.Email);
            SQL += ",@Phonenumber=" + _dao.FilterString(model.Phonenumber);
            SQL += ",@Country=" + _dao.FilterString(model.Country);
            SQL += ",@City=" + _dao.FilterString(model.City);
            SQL += ",@DrivingLicence=" + _dao.FilterString(model.DrivingLicence);
            SQL += ",@Image=" + _dao.FilterString(model.Image);
            var dbresponse = _dao.ExecuteDataRow(SQL);
            if (dbresponse != null)
            {
                string code = _dao.ParseColumnValue(dbresponse, "code").ToString();
                string message = _dao.ParseColumnValue(dbresponse, "message").ToString();
                if (code == "000" || code == "0")
                {
                    return new CommonModel()
                    {
                        Code = ResponseCode.SUCCESS,
                        Message = "Successfully retrieved vehicle List",
                        Data = null
                    };
                }
                else
                {
                    return new CommonModel()
                    {
                        Code = ResponseCode.FAILED,
                        Message = "FAILED",
                        Data = null
                    };
                }
            }
            else
            {
                return new CommonModel()
                {
                    Code = ResponseCode.FAILED,
                    Message = "Database returned NULL",
                    Data = null
                };
            }
        }
    }
    #region INTERFACE
    public interface IBookingRepo
    {
        CommonModel BookVehicle(string vid);
        CommonModel SaveBooking(BookingModel model);
    }
    #endregion
}
