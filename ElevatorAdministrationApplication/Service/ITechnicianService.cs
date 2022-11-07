using ElevatorAdministrationApplication.Models;

namespace ElevatorAdministrationApplication.Service
{
    public interface ITechnicianService
    {
        public TechnicianModel GetTechnician(int id);
        public List<TechnicianModel> GetTechnicians();
    }
}
