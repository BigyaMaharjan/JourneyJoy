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

        public CommonModel GetUserDetails(string UID)
        {
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sp_LogIn @flag= 'gud' "; //Get user Details
            SqlCommand += ",@UID=" + _dao.FilterString(UID);
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
                    ResponseModel.Phonenumber = _dao.ParseColumnValue(Response, "MobileNo").ToString();
                    ResponseModel.Gender = _dao.ParseColumnValue(Response, "UserType").ToString();
                    ResponseModel.ProfileImage = _dao.ParseColumnValue(Response, "ProfileImage").ToString();
                    ResponseModel.DrivingLicence = _dao.ParseColumnValue(Response, "DriverLicenceNumber").ToString();
                    ResponseModel.Country = _dao.ParseColumnValue(Response, "Country").ToString();
                    ResponseModel.City = _dao.ParseColumnValue(Response, "City").ToString();
                    ResponseModel.UserType = _dao.ParseColumnValue(Response, "UserType").ToString();
                    if (ResponseModel.UserType.ToLower() == "vendor")
                    {
                        var SqlCommandAgain = "exec sp_Booking_Vehicle @flag= 'gvbid' "; //Get vehicles by ID
                        SqlCommandAgain += ",@UID=" + _dao.FilterString(UID);
                        var ResponseAgain = _dao.ExecuteDataRow(SqlCommandAgain);
                        if (ResponseAgain != null)
                        {
                            string codeAgain = _dao.ParseColumnValue(Response, "code").ToString();
                            string messageAgain = _dao.ParseColumnValue(Response, "message").ToString();
                            if (codeAgain == "000" || codeAgain == "0")
                            {
                                ResponseModel.VehicleID = _dao.ParseColumnValue(Response, "VehicleID").ToString();
                                ResponseModel.VehicleType = _dao.ParseColumnValue(Response, "VehicleType").ToString();
                                ResponseModel.VehicleMdl = _dao.ParseColumnValue(Response, "VehicleModel").ToString();
                                ResponseModel.CarCapacity = _dao.ParseColumnValue(Response, "VehicleCapacity").ToString();
                                ResponseModel.Rating = _dao.ParseColumnValue(Response, "Rating").ToString();
                                ResponseModel.TotalSeats = _dao.ParseColumnValue(Response, "TotalSeats").ToString();
                                ResponseModel.TotalMilage = _dao.ParseColumnValue(Response, "TotalMilage").ToString();
                                ResponseModel.ProfileImage = _dao.ParseColumnValue(Response, "ProfileImage").ToString();
                                ResponseModel.TotalPrice = _dao.ParseColumnValue(Response, "TotalPrice").ToString();
                                ResponseModel.Detail = _dao.ParseColumnValue(Response, "Detail").ToString();
                                ResponseModel.City = _dao.ParseColumnValue(Response, "City").ToString();
                            }
                        }
                    }
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

        public CommonModel Login(LogInModel model)
        {
            var CommonModel = new CommonModel();
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sp_LogIn @flag= 'L' ";
            SqlCommand += ",@CustomerName=" + _dao.FilterString(model.Firstname);
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
                    ResponseModel.Phonenumber = _dao.ParseColumnValue(Response, "MobileNo").ToString();
                    ResponseModel.Gender = _dao.ParseColumnValue(Response, "Gender").ToString();
                    ResponseModel.Title = _dao.ParseColumnValue(Response, "Title").ToString();
                    ResponseModel.ProfileImage = _dao.ParseColumnValue(Response, "ProfileImage").ToString();
                    ResponseModel.DrivingLicence = _dao.ParseColumnValue(Response, "DriverLicenceNumber").ToString();
                    ResponseModel.Country = _dao.ParseColumnValue(Response, "Country").ToString();
                    ResponseModel.City = _dao.ParseColumnValue(Response, "City").ToString();
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
            SqlCommand += ",@CustomerName=" + _dao.FilterString(model.Firstname);
            SqlCommand += ",@Mobilenumber=" + _dao.FilterString(model.Mobilenumber);
            SqlCommand += ",@Email=" + _dao.FilterString(model.Email);
            SqlCommand += ",@UserType=" + _dao.FilterString(model.UserType);
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

        public CommonModel SaveContactInformation(CustomerModel model)
        {
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sproc_customer_registration @flag= 'cu' "; //contact us 
            SqlCommand += ",@FirstName=" + _dao.FilterString(model.FirstName);
            SqlCommand += ",@LastName=" + _dao.FilterString(model.LastName);
            SqlCommand += ",@Vehicle=" + _dao.FilterString(model.Vehicle);
            SqlCommand += ",@Email=" + _dao.FilterString(model.Email);
            SqlCommand += ",@Bio=" + _dao.FilterString(model.Description);
            var Response = _dao.ExecuteDataRow(SqlCommand);
            if (Response != null)
            {
                string code = _dao.ParseColumnValue(Response, "code").ToString();
                string message = _dao.ParseColumnValue(Response, "message").ToString();
                if (code == "000" || code == "0")
                {
                    ResponseModel.FirstName = _dao.ParseColumnValue(Response, "FirstName").ToString();
                    ResponseModel.LastName = _dao.ParseColumnValue(Response, "LastName").ToString();
                    ResponseModel.Vehicle = _dao.ParseColumnValue(Response, "Vehicle").ToString();
                    ResponseModel.Email = _dao.ParseColumnValue(Response, "Email").ToString();
                    ResponseModel.Bio = _dao.ParseColumnValue(Response, "Description").ToString();
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

        public CommonModel UpdateUserProfile(BookingModel model)
        {
            var ResponseModel = new LogInResponseModel();
            var SqlCommand = "exec sproc_customer_registration @flag= 'uup' "; //Update User Profile
            SqlCommand += ",@UserName=" + _dao.FilterString(model.Username);
            SqlCommand += ",@Email=" + _dao.FilterString(model.Email);
            SqlCommand += ",@City=" + _dao.FilterString(model.City);
            SqlCommand += ",@Country=" + _dao.FilterString(model.Country);
            SqlCommand += ",@DriverLicenceNumber=" + _dao.FilterString(model.DrivingLicence);
            SqlCommand += ",@UID=" + _dao.FilterString(model.UID);
            SqlCommand += ",@ProfileImage=" + _dao.FilterString(model.Image);
            var Response = _dao.ExecuteDataRow(SqlCommand);
            if (Response != null)
            {
                string code = _dao.ParseColumnValue(Response, "code").ToString();
                string message = _dao.ParseColumnValue(Response, "message").ToString();
                return new CommonModel()
                {
                    Code = (code == "000" || code == "0") ? ResponseCode.SUCCESS : ResponseCode.FAILED,
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
        CommonModel GetUserDetails(string uID);
        CommonModel Login(LogInModel model);
        CommonModel RegisterNewUser(LogInModel model);
        CommonModel SaveContactInformation(CustomerModel model);
        CommonModel UpdateUserProfile(BookingModel model);
    }
    #endregion
}