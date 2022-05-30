namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string fullName, string email, DateTime birthdate)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Birthdate = birthdate;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
