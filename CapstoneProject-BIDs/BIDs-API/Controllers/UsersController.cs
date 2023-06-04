using Microsoft.AspNetCore.Mvc;
using Data_Access.Entities;
using Business_Logic.Modules.UserModule.Interface;
using Business_Logic.Modules.UserModule.Request;

namespace BIDs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersForAdmin()
        {
            try
            {
                var response = await _userService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByID([FromRoute] Guid id)
        {
            var user = await _userService.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET api/<ValuesController>/abc
        [HttpGet("by_name/{name}")]
        public async Task<ActionResult<User>> GetUserByName([FromRoute] string name)
        {
            var user = await _userService.GetUserByName(name);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                await _userService.UpdateUser(updateUserRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ValuesController>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                return Ok(await _userService.AddNewUser(createUserRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //private bool UserExists(Guid id)
        //{
        //    return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        //}
    }
}
