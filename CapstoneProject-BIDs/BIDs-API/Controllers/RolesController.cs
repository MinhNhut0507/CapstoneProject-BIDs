using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access.Entities;
using Business_Logic.Modules.RoleModule.Interface;
using Business_Logic.Modules.RoleModule.Request;

namespace BIDs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _RoleService;

        public RolesController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        // GET api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRolesForAdmin()
        {
            try
            {
                var response = await _RoleService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRoleByID([FromRoute] Guid id)
        {
            var Role = await _RoleService.GetRoleByID(id);

            if (Role == null)
            {
                return NotFound();
            }

            return Role;
        }

        // GET api/<ValuesController>/abc
        [HttpGet("by_name/{name}")]
        public async Task<ActionResult<Role>> GetRoleByName([FromRoute] string name)
        {
            var Role = await _RoleService.GetRoleByName(name);

            if (Role == null)
            {
                return NotFound();
            }

            return Role;
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutRole([FromBody] UpdateRoleRequest updateRoleRequest)
        {
            try
            {
                await _RoleService.UpdateRole(updateRoleRequest);
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
        public async Task<ActionResult<Role>> PostRole([FromBody] CreateRoleRequest createRoleRequest)
        {
            try
            {
                return Ok(await _RoleService.AddNewRole(createRoleRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole([FromRoute] Guid id)
        {
            try
            {
                await _RoleService.DeleteRole(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
