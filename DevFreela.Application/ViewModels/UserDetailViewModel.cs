namespace DevFreela.Application.ViewModels
{
    public class UserDetailViewModel
    {
        public UserDetailViewModel(int id, string fullName, string email, bool active, DateTime birthdate, DateTime createdAt)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Active = active;
            Birthdate = birthdate;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
