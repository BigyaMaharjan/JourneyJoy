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
        public CommonModel Login(CustomerModel model)
        {
            var CommonModel = new CommonModel();
            var SqlCommand = "exe login @flag= 'L' ";
            SqlCommand += ",@CustomerName=" + model.CustomerName;
            SqlCommand += ",@Password=" + model.Password;
            SqlCommand += ",@MobileNumber=" + model.MobileNumber;
            return CommonModel;
        }
    }

    #region INTERFACE
    public interface ILoginRepo
    {
        CommonModel Login(CustomerModel model);
    }
    #endregion
}