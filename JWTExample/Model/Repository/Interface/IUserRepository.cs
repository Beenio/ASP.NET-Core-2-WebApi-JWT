using JWTExample.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Model.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
    }
}
