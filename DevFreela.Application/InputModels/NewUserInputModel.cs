namespace DevFreela.Application.InputModels
{
    public class NewUserInputModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
    }
}
