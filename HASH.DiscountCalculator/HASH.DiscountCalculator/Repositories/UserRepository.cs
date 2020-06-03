using HASH.DiscountCalculator.Data;
using HASH.DiscountCalculator.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _context.Users.Find(p => p.Id == userId).FirstOrDefaultAsync(); ;
        }

        public async Task<List<User>> GetAllUsers()
        {  
            return await _context.Users.Find(_ => true).ToListAsync();
        }
    }
}

