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
                FirstName = "Joao",
                LastName = "Carlos",
                BirthDate = new DateTime(1993, 6, 18)
            },
            new User()
            {
                Id = "2",
                FirstName = "Ana",
                LastName = "Claudia",
                BirthDate = new DateTime(1989, 11, 25)
            },
            new User()
            {
                Id = "3",
                FirstName = "Maria",
                LastName = "Luiza'",
                BirthDate = DateTime.Now
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

