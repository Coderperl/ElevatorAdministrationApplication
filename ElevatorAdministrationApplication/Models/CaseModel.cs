namespace ElevatorAdministrationApplication.Models
{
    public class CaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ElevatorModel Elevator { get; set; }
        public TechnicianModel Technician { get; set; }
		public List<CommentModel> Comments { get; set; }
		public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CaseCreated { get; set; }
        public DateTime CaseEnded { get; set; }
    }
}
