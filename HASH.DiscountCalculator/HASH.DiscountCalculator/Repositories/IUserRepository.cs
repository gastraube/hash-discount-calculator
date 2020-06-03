using HASH.DiscountCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string userId);
        Task<List<User>> GetAllUsers();
    }
}
