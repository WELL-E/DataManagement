using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;

namespace DataManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET<td style="border<td style="border: 1px dashed #ababab;"> 1px dashed #ababab;"> api/user  
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.GetAllUser();
        }

        // GET api/user/5  
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userManager.GetUserById(id);
        }

        // POST api/user  
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userManager.AddUser(user);
        }

        // PUT api/user/5  
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _userManager.UpdateUser(user);
        }

        // DELETE api/user/5  
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userManager.DeleteUser(id);
        }
    }
}
