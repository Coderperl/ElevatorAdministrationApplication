namespace ElevatorAdministrationApplication.Models.ViewModels
{
    public class CreateCaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ElevatorModel Elevator { get; set; }
        public TechnicianModel Technician { get; set; }
        public CommentModel Comment { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CaseCreated { get; set; }
        public DateTime CaseEnded { get; set; }
    }
}
