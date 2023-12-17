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
            return null;
        }
    }

    #region INTERFACE
    public interface ILoginRepo
    {
        CommonModel Login(LogInModel model);
    }
    #endregion
}