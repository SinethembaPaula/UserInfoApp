using UserInfoApp.Domain.Entities;
using UserInfoApp.Domain.Interfaces;

namespace UserInfoApp.Application.Services
{
    public interface IUserService
    {
        Person GetById(int id);
        void UpdateInfo(Info info);
        void UpdatePassword(int id, string newPassword);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Person GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void UpdateInfo(Info info)
        {
            _repo.UpdateInfo(info);
            _repo.Save();
        }

        public void UpdatePassword(int id, string newPassword)
        {
            var user = _repo.GetById(id);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _repo.Update(user);
                _repo.Save();
            }
        }
    }
}
