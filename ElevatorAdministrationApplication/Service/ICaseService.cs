using ElevatorAdministrationApplication.Models;
using ElevatorAdministrationApplication.Models.ViewModels;

namespace ElevatorAdministrationApplication.Service
{
    public interface ICaseService
    {
        public CaseModel GetCase(int id);
        public List<CaseModel> GetCases();
        public Status UpdateCases(UpdateCaseViewModel updateCase, int Id);
        public Status CreateCase(CreateCaseViewModel createCase);
    }
}
