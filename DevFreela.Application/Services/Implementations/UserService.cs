using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.AuthServices;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IAuthService _authService;

        public UserService(DevFreelaDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);

            var user = new User(
                inputModel.Fullname,
                inputModel.Email,
                passwordHash,
                inputModel.Role,
                inputModel.Birthday);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            user.Inactive();

            _dbContext.SaveChanges();
        }

        public List<UserViewModel> GetAll()
        {
            var users = _dbContext.Users;

            var usersViewModel = users
                .Select(u => new UserViewModel(u.Id, u.FullName, u.Email, u.BirthDate))
                .ToList();

            return usersViewModel;
        }

        public UserDetailViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            var userViewModel = new UserDetailViewModel(
                user.Id,
                user.FullName,
                user.Email,
                user.Active,
                user.BirthDate,
                user.CreatedAt
                );

            return userViewModel;
        }

        public void Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);

            user.Update(user.FullName, user.Email, user.BirthDate);

            _dbContext.SaveChanges();
        }
    }
}
