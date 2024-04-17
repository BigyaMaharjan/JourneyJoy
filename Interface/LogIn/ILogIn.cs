using JourneyJoy.Models;
using JourneyJoy.Repository.Login;

namespace JourneyJoy.Interface.LogIn
{
    public class Login : ILogIn
    {
        ILoginRepo _Repo;

        public Login(LoginRepo repo)
        {
            _Repo = repo;
        }

        public CommonModel GetAllUsers()
        {
            return _Repo.GetAllUsers();
        }

        public CommonModel GetBookedList()
        {
            return _Repo.GetBookedList();
        }

        public CommonModel GetUserDetails(string UID)
        {
            return _Repo.GetUserDetails(UID);
        }

        public CommonModel GetVehicleList()
        {
            return _Repo.GetVehicleList();
        }

        public  CommonModel LogIn(LogInModel model)
        {
            return _Repo.Login(model);
        }

        public CommonModel RegisterNewUser(LogInModel model)
        {
            return _Repo.RegisterNewUser(model);
        }

        public CommonModel SaveContactInformation(CustomerModel model)
        {
            return _Repo.SaveContactInformation(model);
        }

        public CommonModel UpdateUserProfile(BookingModel model)
        {
            return _Repo.UpdateUserProfile(model);
        }
    }

    #region INTERFACE
    public interface ILogIn
    {
        CommonModel GetUserDetails(string UID);
        CommonModel LogIn(LogInModel model);
        CommonModel RegisterNewUser(LogInModel model);
        CommonModel SaveContactInformation(CustomerModel model);
        CommonModel UpdateUserProfile(BookingModel model);
        #region ADMIN
        CommonModel GetAllUsers();
        CommonModel GetBookedList();
        CommonModel GetVehicleList();
        #endregion
    }
    #endregion
}