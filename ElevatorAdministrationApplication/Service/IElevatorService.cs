using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;

namespace ElevatorAdministrationApplication.Service
{
    public interface IElevatorService
    {
        public ElevatorViewModel GetElevator(int id);
        public List<ElevatorListViewModel> GetElevators();
    }
}
