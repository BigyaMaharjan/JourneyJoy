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

        #region Index Page Searches
        public Dictionary<string, string> GetLocationList()
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            string SQL = "EXEC sp_SearchVehicleList @Flag='00l'";
            var dbResponse = _dao.ExecuteDataTable(SQL);
            if (dbResponse != null && dbResponse.Rows.Count > 0)
            {
                foreach (DataRow item in dbResponse.Rows)
                    response.Add(item["Value"].ToString(), item["Text"].ToString());
            }
            return response;
        }

        public CommonModel GetVehicleList(RentSearchModel model)
        {
            var SearchedList = new List<VehicleModel>();
            var SQL = "Exec sp_SearchVehicleList  @Flag='gsvcl'"; // gsvcl- Get Searched Vechicle Category List
            SQL += ",@id=" + _dao.FilterString(model.location);
            SQL += ",@VehicleCategory=" + _dao.FilterString(model.VehicleCategory);
            var dbresponse = _dao.ExecuteDataTable(SQL);
            if (dbresponse != null)
            {
                foreach (DataRow item in dbresponse.Rows)
                {
                    SearchedList.Add(new VehicleModel()
                    {
                        Code = _dao.ParseColumnValue(item, "code").ToString(),
                        Message = _dao.ParseColumnValue(item, "message").ToString(),
                        UserID = _dao.ParseColumnValue(item, "UserID").ToString(),
                        UserName = _dao.ParseColumnValue(item, "UserName").ToString(),
                        LocationId = _dao.ParseColumnValue(item, "LocationId").ToString(),
                        LocationName = _dao.ParseColumnValue(item, "LocationName").ToString(),
                        VehicleID = _dao.ParseColumnValue(item, "VehicleID").ToString(),
                        VehicleType = _dao.ParseColumnValue(item, "VehicleType").ToString(),
                        VehicleMdl = _dao.ParseColumnValue(item, "VehicleModel").ToString(),
                        Title = _dao.ParseColumnValue(item, "Title").ToString(),
                        CarCapacity = _dao.ParseColumnValue(item, "VehicleCapacity").ToString(),
                        Rating = _dao.ParseColumnValue(item, "Rating").ToString(),
                        TotalSeats = _dao.ParseColumnValue(item, "TotalSeats").ToString(),
                        TotalMilage = _dao.ParseColumnValue(item, "TotalMilage").ToString(),
                        TotalPrice = _dao.ParseColumnValue(item, "TotalPrice").ToString(),
                        Image = _dao.ParseColumnValue(item, "ProfileImage").ToString(),
                        Detail = _dao.ParseColumnValue(item, "Detail").ToString(),
                        IsAvailable = _dao.ParseColumnValue(item, "IsAvailable").ToString()
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
        #endregion

        #region Get Vehicle by (ID / Type)
        public CommonModel GetVehicleById(string iD)
        {
            var SearchedtypeList = new VehicleTypeModel();
            var SQL = "Exec sp_SearchVehicleList  @Flag='vid'"; // vid Vehicle ID
            SQL += ",@id=" + _dao.FilterString(iD);
            var dbresponse = _dao.ExecuteDataRow(SQL);
            if (dbresponse != null)
            {
                string code = _dao.ParseColumnValue(dbresponse, "code").ToString();
                string message = _dao.ParseColumnValue(dbresponse, "message").ToString();
                if (code == "000" || code == "0")
                {
                    SearchedtypeList.UserID = _dao.ParseColumnValue(dbresponse, "UserID").ToString();
                    SearchedtypeList.UserName = _dao.ParseColumnValue(dbresponse, "UserName").ToString();
                    SearchedtypeList.VehicleID = _dao.ParseColumnValue(dbresponse, "VehicleID").ToString();
                    SearchedtypeList.VehicleType = _dao.ParseColumnValue(dbresponse, "VehicleType").ToString();
                    SearchedtypeList.Title = _dao.ParseColumnValue(dbresponse, "Title").ToString();
                    SearchedtypeList.VehicleCapacity = _dao.ParseColumnValue(dbresponse, "VehicleCapacity").ToString();
                    SearchedtypeList.Rating = _dao.ParseColumnValue(dbresponse, "Rating").ToString();
                    SearchedtypeList.TotalSeats = _dao.ParseColumnValue(dbresponse, "TotalSeats").ToString();
                    SearchedtypeList.IsAvailable = _dao.ParseColumnValue(dbresponse, "IsAvailable").ToString();
                    SearchedtypeList.TotalMilage = _dao.ParseColumnValue(dbresponse, "TotalMilage").ToString();
                    SearchedtypeList.ProfileImage = _dao.ParseColumnValue(dbresponse, "ProfileImage").ToString();
                    SearchedtypeList.TotalPrice = _dao.ParseColumnValue(dbresponse, "TotalPrice").ToString();
                    SearchedtypeList.Detail = _dao.ParseColumnValue(dbresponse, "Detail").ToString();
                    return new CommonModel()
                    {
                        Code = ResponseCode.SUCCESS,
                        Message = "Successfully retrieved vehicle List",
                        Data = SearchedtypeList
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

        public CommonModel GetVehicleByType(string type)
        {
            var SearchedtypeList = new List<VehicleTypeModel>();
            var SQL = "Exec sp_SearchVehicleList  @Flag='vtype'"; // vtype Vehicle type
            SQL += ",@Title=" + _dao.FilterString(type);
            var dbresponse = _dao.ExecuteDataTable(SQL);
            if (dbresponse != null)
            {
                foreach (DataRow item in dbresponse.Rows)
                {
                    SearchedtypeList.Add(new VehicleTypeModel()
                    {
                        UserID = _dao.ParseColumnValue(item, "UserID").ToString(),
                        UserName = _dao.ParseColumnValue(item, "UserName").ToString(),
                        VehicleID = _dao.ParseColumnValue(item, "VehicleID").ToString(),
                        VehicleType = _dao.ParseColumnValue(item, "VehicleType").ToString(),
                        Title = _dao.ParseColumnValue(item, "Title").ToString(),
                        VehicleCapacity = _dao.ParseColumnValue(item, "VehicleCapacity").ToString(),
                        Rating = _dao.ParseColumnValue(item, "Rating").ToString(),
                        TotalSeats = _dao.ParseColumnValue(item, "TotalSeats").ToString(),
                        IsAvailable = _dao.ParseColumnValue(item, "IsAvailable").ToString(),
                        TotalMilage = _dao.ParseColumnValue(item, "TotalMilage").ToString(),
                        ProfileImage = _dao.ParseColumnValue(item, "ProfileImage").ToString(),
                        TotalPrice = _dao.ParseColumnValue(item, "TotalPrice").ToString(),
                        Detail = _dao.ParseColumnValue(item, "Detail").ToString(),
                    });
                }
                return new CommonModel()
                {
                    Code = ResponseCode.SUCCESS,
                    Message = "Successfully retrieved vehicle List",
                    Data = SearchedtypeList
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
        #endregion

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
                        CarCapacity = _dao.ParseColumnValue(item, "VehicleCapacity").ToString(),
                        TotalSeats = _dao.ParseColumnValue(item, "TotalSeats").ToString(),
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
    }
}

#region INTERFACE
public interface IVehicleRepo
{
    Dictionary<string, string> GetLocationList();
    CommonModel GetRecentlyAddedVehicleList();
    CommonModel GetVehicleById(string iD);
    CommonModel GetVehicleByType(string type);
    CommonModel GetVehicleList(RentSearchModel model);
}
#endregion