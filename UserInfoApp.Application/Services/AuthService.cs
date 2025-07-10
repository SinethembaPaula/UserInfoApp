using UserInfoApp.Domain.Entities;
using UserInfoApp.Domain.Interfaces;

namespace UserInfoApp.Application.Services
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password, out Person person);
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;

        public AuthService(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool ValidateUser(string username, string password, out Person person)
        {
            person = _repo.GetByUsername(username);
            if (person == null) return false;
            return BCrypt.Net.BCrypt.Verify(password, person.Password);
        }
    }
}
