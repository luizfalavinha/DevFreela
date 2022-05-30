namespace DevFreela.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(string fullName, string title, DateTime birthDate)
        {
            FullName = fullName;
            Title = title;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string FullName { private get; set; }
        public string Title { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
