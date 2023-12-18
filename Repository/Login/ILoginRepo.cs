using JourneyJoy.Database;
using JourneyJoy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JourneyJoy.Repository.Login
{
    public class LoginRepo : ILoginRepo
    {
        DatabaseAccessObject _dao;
        public LoginRepo()
        {
            _dao = new DatabaseAccessObject();
        }
        public CommonModel Login(LogInModel model)
        {
            var CommonModel = new CommonModel();
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sp_LogIn @flag= 'L' ";
            SqlCommand += ",@CustomerName=" + _dao.FilterString(model.LogInID);
            SqlCommand += ",@Password=" + _dao.FilterString(model.password);
            var Response = _dao.ExecuteDataRow(SqlCommand);
            if( Response != null)
            {
                string code = _dao.ParseColumnValue(Response, "code").ToString();
                string message = _dao.ParseColumnValue(Response, "message").ToString();
                ResponseModel.Username = _dao.ParseColumnValue(Response, "CustomerName").ToString();
                ResponseModel.MobileNumber = _dao.ParseColumnValue(Response, "MobileNumber").ToString();
                //ResponseModel.Age = _dao.ParseColumnValue(Response, "Age").ToString();
                //ResponseModel.Title = _dao.ParseColumnValue(Response, "Title").ToString();
                //ResponseModel.CustomerID = _dao.ParseColumnValue(Response, "CustomerID").ToString();
                //ResponseModel.Email = _dao.ParseColumnValue(Response, "Email").ToString();
                //ResponseModel.Bio = _dao.ParseColumnValue(Response, "Bio").ToString();
                //ResponseModel.ProfileImage = _dao.ParseColumnValue(Response, "ProfileImage").ToString();
                //ResponseModel.Country = _dao.ParseColumnValue(Response, "Country").ToString();
                //ResponseModel.City = _dao.ParseColumnValue(Response, "City").ToString();
                //ResponseModel.PostCode = _dao.ParseColumnValue(Response, "PostCode").ToString();
                //ResponseModel.DriverLicenceNumber = _dao.ParseColumnValue(Response, "DriverLicenceNumber").ToString();
                //ResponseModel.UserType = _dao.ParseColumnValue(Response, "UserType").ToString();
                return new CommonModel()
                {
                    Code = ResponseCode.SUCCESS,
                    Message = message,
                    Data = ResponseModel
                };
            }
            else
            {
                return new CommonModel()
                {
                    Code = ResponseCode.FAILED,
                    Message = "Couldn't retrieve the data",
                    Data = null
                };
            }
            
        }
    }

    #region INTERFACE
    public interface ILoginRepo
    {
        CommonModel Login(LogInModel model);
    }
    #endregion
}