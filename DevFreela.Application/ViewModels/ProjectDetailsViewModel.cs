namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(
            int id,
            string title,
            string description,
            decimal totalCost,
            DateTime? startedAt,
            DateTime? finishedAt,
            string clientFullName,
            string freelancerFulNname
        )
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName = clientFullName;
            FreelancerFulNname = freelancerFulNname;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFulNname { get; private set; }
    }
}
