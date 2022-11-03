using ElevatorAdministrationApplication.Models;

namespace ElevatorAdministrationApplication.Service
{
    public interface ICaseService
    {
        public CaseModel GetCase(int id);
        public List<CaseModel> GetCases();
        public Status UpdateCases(CaseModel updateCase, int Id);
        public Status CreateCase(CaseModel createCase);
    }
}
