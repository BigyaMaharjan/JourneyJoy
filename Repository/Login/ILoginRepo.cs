using JourneyJoy.Database;
using JourneyJoy.Models;

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
            SqlCommand += ",@CustomerName=" + _dao.FilterString(model.Mobilenumber);
            SqlCommand += ",@Password=" + _dao.FilterString(model.password);
            var Response = _dao.ExecuteDataRow(SqlCommand);
            if (Response != null)
            {
                string code = _dao.ParseColumnValue(Response, "code").ToString();
                string message = _dao.ParseColumnValue(Response, "message").ToString();
                if (code == "000" || code == "0")
                {
                    ResponseModel.CustomerID = _dao.ParseColumnValue(Response, "UserID").ToString();
                    ResponseModel.Username = _dao.ParseColumnValue(Response, "UserName").ToString();
                    ResponseModel.Email = _dao.ParseColumnValue(Response, "Email").ToString();
                    ResponseModel.MobileNumber = _dao.ParseColumnValue(Response, "MobileNo").ToString();
                    ResponseModel.Gender = _dao.ParseColumnValue(Response, "Gender").ToString();
                    ResponseModel.Title = _dao.ParseColumnValue(Response, "Title").ToString();
                    ResponseModel.ProfileImage = _dao.ParseColumnValue(Response, "ProfileImage").ToString();
                    ResponseModel.DriverLicenceNumber = _dao.ParseColumnValue(Response, "DriverLicenceNumber").ToString();
                    ResponseModel.Country = _dao.ParseColumnValue(Response, "Country").ToString();
                    ResponseModel.City = _dao.ParseColumnValue(Response, "City").ToString();
                    ResponseModel.PostCode = _dao.ParseColumnValue(Response, "PostCode").ToString();
                    ResponseModel.Bio = _dao.ParseColumnValue(Response, "Bio").ToString();
                    ResponseModel.UserType = _dao.ParseColumnValue(Response, "UserType").ToString();
                    return new CommonModel()
                    {
                        Code = ResponseCode.SUCCESS,
                        Message = message,
                        Data = ResponseModel
                    };
                }
                return new CommonModel()
                {
                    Code = ResponseCode.FAILED,
                    Message = message,
                    Data = null
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

        public CommonModel RegisterNewUser(LogInModel model)
        {
            var CommonModel = new CommonModel();
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sp_LogIn @flag= 'reg' "; //customer registration
            SqlCommand += ",@Firstname=" + _dao.FilterString(model.Firstname);
            SqlCommand += ",@Lastname=" + _dao.FilterString(model.Lastname);
            SqlCommand += ",@Mobilenumber=" + _dao.FilterString(model.Mobilenumber);
            SqlCommand += ",@Email=" + _dao.FilterString(model.Email);
            SqlCommand += ",@Password=" + _dao.FilterString(model.password);
            SqlCommand += ",@confirmpassword=" + _dao.FilterString(model.confirmpassword);
            var Response = _dao.ExecuteDataRow(SqlCommand);
            if (Response != null)
            {
                string code = _dao.ParseColumnValue(Response, "code").ToString();
                string message = _dao.ParseColumnValue(Response, "message").ToString();
                if (code == "000" || code == "0")
                {                    
                    return new CommonModel()
                    {
                        Code = ResponseCode.SUCCESS,
                        Message = message,
                        Data = ResponseModel
                    };
                }
                return new CommonModel()
                {
                    Code = ResponseCode.FAILED,
                    Message = message,
                    Data = null
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
        CommonModel RegisterNewUser(LogInModel model);
    }
    #endregion
}