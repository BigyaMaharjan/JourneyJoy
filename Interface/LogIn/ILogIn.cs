using JourneyJoy.Models;
using JourneyJoy.Repository.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyJoy.Interface.LogIn
{
    public class Login : ILogIn
    {
        ILoginRepo _Repo;

        public  CommonModel LogIn(LogInModel model)
        {
            return _Repo.Login(model);
        }
    }

    #region INTERFACE
    public interface ILogIn
    {
        CommonModel LogIn(LogInModel model);
    }
    #endregion
}
