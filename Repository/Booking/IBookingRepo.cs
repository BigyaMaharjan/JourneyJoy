using JourneyJoy.Database;
using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Data;

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

        public CommonModel GetUserBookings(string UID)
        {
            var SearchedList = new List<VehicleModel>();
            var SQL = "Exec sp_Booking_Vehicle  @Flag='gbvl'"; // gbvl- Get booking vehicle lsit
            SQL += ",@UID=" + _dao.FilterString(UID);
            var dbresponse = _dao.ExecuteDataTable(SQL);
            if (dbresponse != null)
            {
                foreach (DataRow item in dbresponse.Rows)
                {
                    SearchedList.Add(new VehicleModel()
                    {
                        BID = _dao.ParseColumnValue(item, "BID").ToString(),
                        VehicleID = _dao.ParseColumnValue(item, "VehicleID").ToString(),
                        VehicleType = _dao.ParseColumnValue(item, "VehicleType").ToString(),
                        Rating = _dao.ParseColumnValue(item, "Rating").ToString(),
                        VehicleMdl = _dao.ParseColumnValue(item, "VehicleModel").ToString(),
                        TotalMilage = _dao.ParseColumnValue(item, "TotalMilage").ToString(),
                        CarCapacity = _dao.ParseColumnValue(item, "VehicleCapacity").ToString(),
                        Image = _dao.ParseColumnValue(item, "ProfileImage").ToString(),
                        TotalPrice = _dao.ParseColumnValue(item, "TotalPrice").ToString(),
                        Detail = _dao.ParseColumnValue(item, "Detail").ToString(),
                        BookingStatus = _dao.ParseColumnValue(item, "BookingStatus").ToString()
                    });
                }
                return new CommonModel()
                {
                    Code = ResponseCode.SUCCESS,
                    Message = "Successfully retrieved recently added vehicle List",
                    Data = SearchedList
                };
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

        public CommonModel SaveBooking(BookingModel model)
        {
            var SQL = "Exec sp_Booking_Vehicle  @Flag='bv'"; // book vehicle
            SQL += ",@Username=" + _dao.FilterString(model.Username);
            SQL += ",@UID=" + _dao.FilterString(model.UID);
            SQL += ",@VID=" + _dao.FilterString(model.VID);
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
        CommonModel GetUserBookings(string uID);
        CommonModel SaveBooking(BookingModel model);
    }
    #endregion
}
