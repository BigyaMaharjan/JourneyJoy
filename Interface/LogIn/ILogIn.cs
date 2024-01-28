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

        public  CommonModel LogIn(LogInModel model)
        {
            return _Repo.Login(model);
        }

        public CommonModel RegisterNewUser(LogInModel model)
        {
            return _Repo.RegisterNewUser(model);
        }
    }

    #region INTERFACE
    public interface ILogIn
    {
        CommonModel LogIn(LogInModel model);
        CommonModel RegisterNewUser(LogInModel model);
    }
    #endregion
}