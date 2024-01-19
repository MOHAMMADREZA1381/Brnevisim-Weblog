
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
    }
}
