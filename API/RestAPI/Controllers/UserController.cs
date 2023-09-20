using Business.Users;
using Data;
using Data.Models;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dataContext _dataContext;
        public UserController(dataContext context)
        {
            _dataContext = context;
        }
        /// <summary>
        /// Get all registred users with pagination system
        /// </summary>
        /// <param name="page"></param>
        /// <returns> Response Object </returns>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        [HttpGet("/Users")]
        public IActionResult Get([FromQuery] int page)
        {
            UsersBusiness userBusiness = new UsersBusiness();
            UserDtoResponse response = userBusiness.GetUsers(page, _dataContext).Result;

            return Ok((response));
        }
        /// <summary>
        /// Get user by ID - Authentication Required 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object type User</returns>
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [Authorize]
        [HttpGet("/Users/{id}")]
        public IActionResult GetUserById(int id)
        {

            UsersBusiness userBusiness = new UsersBusiness();
            UserDto response = userBusiness.GetUser(id, _dataContext).Result;

            return Ok((response));
        }
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User created</returns>
     
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersBusiness userBusiness = new UsersBusiness();
            var response = await  userBusiness.CreateUser(user, _dataContext);
         

            return CreatedAtAction("GetUserById", new { id = user.id }, response);
        }
        /// <summary>
        /// Update data of some user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>User</returns>
  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersBusiness userBusiness = new UsersBusiness();
            var response = await userBusiness.UpdateUser(id, user, _dataContext);
            if (response == null) {
                return NotFound();
            }


            return NoContent();
        }
    }
}
