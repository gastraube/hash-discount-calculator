using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public UserModel ParseToUserModel()
        {
            return new UserModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = BirthDate.ToString()
            };
        }
    }
}
