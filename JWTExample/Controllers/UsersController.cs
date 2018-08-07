using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTExample.Model.Entity;
using JWTExample.Model.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTExample.Controllers
{
    [Route("api/[controller]"), Authorize]
    public class UsersController : Controller
    {
        private IUserRepository Repository;

        public UsersController(IUserRepository Repository)
        {
            this.Repository = Repository;
        }

        [HttpGet("all")]
        public List<User> AllUsers()
        {
            return Repository.GetAll();
        }

        [HttpGet("get/{id}")]
        public User Get(int id)
        {
            return Repository.Get(id);
        }
    }
}
