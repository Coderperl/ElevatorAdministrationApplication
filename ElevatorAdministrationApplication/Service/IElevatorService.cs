using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;

namespace ElevatorAdministrationApplication.Service
{
    public interface IElevatorService
    {
        public ElevatorModel GetElevator(int id);
        public List<ElevatorModel> GetElevators();
    }
}
