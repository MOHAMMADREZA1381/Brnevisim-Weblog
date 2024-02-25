using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class FollowRepository:IFollowRepository
    {
        #region Context

        

        private readonly BlogContext _context;

        public FollowRepository(BlogContext context)
        {
            _context = context;
        }
        #endregion
        public async Task AddFollow(Following following)
        {
           
                await _context.AddAsync(following);
                await _context.SaveChangesAsync();
            
        }

        public async Task RemoveFollow(Following following)
        {
           
                 _context.Remove(following);
                await _context.SaveChangesAsync();
            
        }

        public async Task<ICollection<Following>> GetFollows(int UserId)
        {
            return await _context.Followings.Where(a => a.UserId == UserId).ToListAsync();
        }

        public async Task<ICollection<Following>> GetFollowers(int UserId)
        {
            return await _context.Followings.Where(a => a.UserIdThatFollowed == UserId).ToListAsync();
        }

        public async Task<bool> FollowedBefor(int UserId, int UserIdWntToFollow)
        {
            return await _context.Followings.AnyAsync(a => a.UserId == UserId && a.UserIdThatFollowed==UserIdWntToFollow);
        }
    }
}
