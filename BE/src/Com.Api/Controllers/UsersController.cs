using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Com.Data;
using Com.Services;
using Com.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Com.Api.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService) 
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserApi>> Get()
        {
            return Ok(_userService.GetUsers().Select(x=>_factory.Create<User, UserApi>(x)).ToList());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserApi> Get(Guid id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_factory.Create<User, UserApi>(user));
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, User user)
        {
            _userService.UpdateUser(id, user);

            if (_userService.GetErrors().Count == 0)
                return NoContent();

            return BadRequest(new ApiError("User could not be updated"));
        }
        
        [AllowAnonymous]
        // POST: api/Users
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            var addedUser =  _userService.Register(user);

            var errors = _userService.GetErrors();
            if (errors.Count == 0)
              return Ok(addedUser);

            return BadRequest(new ApiError($"User could not be created : {errors.FirstOrDefault()}"));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.UserName, userParam.Password);

            var errors = _userService.GetErrors();
            if (errors.Count == 0 && user != null)
            return Ok(user);

           return Unauthorized(new ApiError(errors.FirstOrDefault()));
        }
    }
}
