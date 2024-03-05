using JourneyJoy.Models;
using JourneyJoy.Repository.Vehicle;
using System.Collections.Generic;

namespace JourneyJoy.Interface.Vehicle
{
    public class Vehicle : IVehicle
    {
        IVehicleRepo _Repo;

        public Vehicle(VehicleRepo repo)
        {
            _Repo = repo;
        }

        public Dictionary<string, string> GetLocationList()
        {
            return _Repo.GetLocationList();
        }

        public CommonModel GetRecentlyAddedVehicleList()
        {
            return _Repo.GetRecentlyAddedVehicleList();
        }

        public CommonModel GetVehicleById(string ID)
        {
            return _Repo.GetVehicleById(ID);
        }

        public CommonModel GetVehicleByType(string type)
        {
            return _Repo.GetVehicleByType(type);
        }

        public CommonModel GetVehicleList(RentSearchModel model)
        {
            return _Repo.GetVehicleList(model);
        }
    }

    #region INTERFACE
    public interface IVehicle
    {
        CommonModel GetVehicleList(RentSearchModel model);
        CommonModel GetRecentlyAddedVehicleList();
        Dictionary<string, string> GetLocationList();
        CommonModel GetVehicleByType(string type);
        CommonModel GetVehicleById(string ID);
    }
    #endregion
}