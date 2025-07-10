using UserInfoApp.Domain.Entities;
using UserInfoApp.Domain.Interfaces;
using UserInfoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace UserInfoApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Person GetByUsername(string username)
        {
            return _context.People.Include(p => p.Info)
                .FirstOrDefault(p => p.Name == username);
        }

        public Person GetById(int id)
        {
            return _context.People.Include(p => p.Info)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
        }

        public void UpdateInfo(Info info)
        {
            _context.Infos.Update(info);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
