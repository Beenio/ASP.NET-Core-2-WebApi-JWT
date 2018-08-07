using JWTExample.Model.Entity;
using JWTExample.Model.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Get(int id)
        {
            return new User()
            {
                Id = id,
                Name = $"Test {id}",
                Email = $"test{id}@test.com",
                Age = 15
            };
        }

        public List<User> GetAll()
        {
            return new List<User> {
                new User()
                {
                    Id = 0,
                    Name = "Test",
                    Email = "test@test.com",
                    Age = 15
                },
                new User()
                {
                    Id = 1,
                    Name = "Test 1",
                    Email = "test1@test.com",
                    Age = 15
                },
                new User()
                {
                    Id = 0,
                    Name = "Test 2",
                    Email = "test2@test2.com",
                    Age = 15
                }
            };
        }
    }
}
