using JourneyJoy.Database;
using JourneyJoy.Models;
using System.Collections.Generic;
using System.Data;


namespace JourneyJoy.Repository.Vehicle
{
    public class VehicleRepo : IVehicleRepo
    {
        DatabaseAccessObject _dao;
        public VehicleRepo()
        {
            _dao = new DatabaseAccessObject();
        }

        public CommonModel GetRecentlyAddedVehicleList()
        {
            var SearchedList = new List<VehicleModel>();
            var SQL = "Exec sp_SearchVehicleList  @Flag='gral'"; // gl- Get rectently added  List
            var dbresponse = _dao.ExecuteDataTable(SQL);
            if (dbresponse != null)
            {
                foreach (DataRow item in dbresponse.Rows)
                {
                    SearchedList.Add(new VehicleModel()
                    {
                        VehicleID = _dao.ParseColumnValue(item, "VehicleID").ToString(),
                        VehicleType = _dao.ParseColumnValue(item, "VehicleType").ToString(),
                        Rating = _dao.ParseColumnValue(item, "Rating").ToString(),
                        TotalMilage = _dao.ParseColumnValue(item, "TotalMilage").ToString(),
                        Image = _dao.ParseColumnValue(item, "ProfileImage").ToString(),
                        TotalPrice = _dao.ParseColumnValue(item, "TotalPrice").ToString(),
                        CreatedBy = _dao.ParseColumnValue(item, "CreatedBy").ToString(),
                        CreatedDate = _dao.ParseColumnValue(item, "CreatedDate").ToString(),
                        Detail = _dao.ParseColumnValue(item, "Detail").ToString(),
                        VehicleMdl = _dao.ParseColumnValue(item, "Title").ToString(),
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
}

#region INTERFACE
public interface IVehicleRepo
{
    CommonModel GetRecentlyAddedVehicleList();
    CommonModel GetVehicleList(RentSearchModel model);
}
#endregion