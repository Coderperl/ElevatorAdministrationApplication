namespace ElevatorAdministrationApplication.Models
{
    public class CaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ElevatorModel Elevator { get; set; }
        public TechnicianModel Technician { get; set; }
        public string Status { get; set; }
    }
}
