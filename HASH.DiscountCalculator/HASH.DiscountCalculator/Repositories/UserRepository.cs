using HASH.DiscountCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> userList = new List<User>() {
            new User()
            {
                Id = "1",
                FirstName = "Gabriel",
                LastName = "Straube",
                BirthDate = new DateTime(1993, 6, 18)
            }
        };


        public Task<User> GetUserById(string userId)
        {
            return Task.FromResult(
                userList.Where(user => user.Id == userId).FirstOrDefault()
            );
        }
    }
}

