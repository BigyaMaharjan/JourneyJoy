using JourneyJoy.Database;
using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;


namespace JourneyJoy.Repository.Vehicle
{
    public class VehicleRepo : IVehicleRepo
    {
        DatabaseAccessObject _dao;
        public VehicleRepo()
        {
            _dao = new DatabaseAccessObject();
        }

        public CommonModel GetVehicleList(RentSearchModel model)
        {
            var SearchedList = new List<VehicleModel>();
            var SQL = "Exec sp_SearchVehicleList  @Flag='S'"; // gl- Get List
            SQL += ",@LocationId=" + _dao.FilterString(model.FromLocation);
            //SQL += ",@ToLocation=" + _dao.FilterString(model.ToLocation);
            //SQL += ",@FromTime=" + _dao.FilterString(model.FromTime);
            //SQL += ",@ToTime=" + _dao.FilterString(model.ToTime);
            //SQL += ",@FromDate=" + _dao.FilterString(model.FromDate);
            //SQL += ",@ToDate=" + _dao.FilterString(model.ToDate);
            var dbresponse = _dao.ExecuteDataTable(SQL);
            if (dbresponse != null)
            {
                foreach (DataRow item in dbresponse.Rows)
                {
                    SearchedList.Add(new VehicleModel()
                    {
                        VehicleType = _dao.ParseColumnValue(item, "VehicleType").ToString(),
                        VehicleMdl = _dao.ParseColumnValue(item, "VehicleModel").ToString(),
                        CarCapacity = _dao.ParseColumnValue(item, "VehicleCapacity").ToString(),
                        Rating = _dao.ParseColumnValue(item, "Rating").ToString(),
                        TotalSeats = _dao.ParseColumnValue(item, "TotalSeats").ToString(),
                        TotalMilage = _dao.ParseColumnValue(item, "TotalMilage").ToString(),
                        TotalPrice = _dao.ParseColumnValue(item, "TotalPrice").ToString(),
                        Image = _dao.ParseColumnValue(item, "ProfileImage").ToString(),
                    });
                }
                return new CommonModel()
                {
                    Code = ResponseCode.SUCCESS,
                    Message = "Successfully retrieved vehicle List",
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
    }
    #region INTERFACE
    public interface IVehicleRepo
    {
        CommonModel GetVehicleList(RentSearchModel model);
    }
    #endregion
}
