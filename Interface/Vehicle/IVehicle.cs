using JourneyJoy.Models;
using JourneyJoy.Repository.Vehicle;

namespace JourneyJoy.Interface.Vehicle
{
    public class Vehicle : IVehicle
    {
        IVehicleRepo _Repo;

        public Vehicle(VehicleRepo repo)
        {
            _Repo = repo;
        }

        public CommonModel GetRecentlyAddedVehicleList()
        {
            return _Repo.GetRecentlyAddedVehicleList();
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
    }
    #endregion
}
