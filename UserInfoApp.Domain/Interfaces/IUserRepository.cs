using UserInfoApp.Domain.Entities;

namespace UserInfoApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Person GetByUsername(string username);
        Person GetById(int id);
        void Update(Person person);
        void UpdateInfo(Info info);
        void Save();
    }
}
