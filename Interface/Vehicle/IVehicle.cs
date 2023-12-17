using JourneyJoy.Models;
using JourneyJoy.Repository.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyJoy.Interface.Vehicle
{
    public class Vehicle : IVehicle
    {
        IVehicleRepo _Repo;
        public CommonModel GetVehicleList(RentSearchModel model)
        {
            return _Repo.GetVehicleList(model);
        }
    }

    #region INTERFACE
    public interface IVehicle
    {
        CommonModel GetVehicleList(RentSearchModel model);
    }
    #endregion
}
