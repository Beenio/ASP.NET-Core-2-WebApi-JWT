using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet("all")]
        public List<string> AllUsers()
        {
            return new List<string>() { "1","2","3"};
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }
    }
}
