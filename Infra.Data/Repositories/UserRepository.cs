
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.User;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Context
        private readonly BlogContext _context;
        public UserRepository(BlogContext context)
        {
            _context = context;
        }
        #endregion


        public async Task Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<bool> IsEmailAlreadyRegistered(string email)
        {
           return   _context.Users.Any(a => a.Email == email);

        }

        public async Task<User> GetUserByActivateCode(string activateCode)
        {
           return  _context.Users.SingleOrDefault(a => a.ActivateCode == activateCode);
              
        }

        public async Task GiveUserActiveRole(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUserEmail(string Email)
        {
            return _context.Users.SingleOrDefault(user => user.Email == Email);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(a=>a.Id==id);
            return user;
        }

        public async Task<ICollection<User>> GetUserList()
        {
            var users =  _context.Users.Where(a=>a.IsDelete==false).ToList();
            return users;
        }

        public async Task EditUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
