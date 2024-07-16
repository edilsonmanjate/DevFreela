using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Projects :BaseEntity
    {
        public Projects(string title, string description, int idClient, int idFreelancer, decimal totalCost, DateTime startDate)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            StartDate = startDate;

            Status = ProjectStatusEnum.Created;
            CreatedAt = DateTime.Now;
            Comments = new List<ProjectComment>();
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
