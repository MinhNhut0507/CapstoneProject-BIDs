using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access.Entities;
using Business_Logic.Modules.StaffModule.Interface;
using Business_Logic.Modules.StaffModule.Request;

namespace BIDs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _StaffService;

        public StaffsController(IStaffService StaffService)
        {
            _StaffService = StaffService;
        }

        // GET api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffsForAdmin()
        {
            try
            {
                var response = await _StaffService.GetAll();
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffByID([FromRoute] Guid id)
        {
            var Staff = await _StaffService.GetStaffByID(id);

            if (Staff == null)
            {
                return NotFound();
            }

            return Staff;
        }

        // GET api/<ValuesController>/abc
        [HttpGet("by_name/{name}")]
        public async Task<ActionResult<Staff>> GetStaffByName([FromRoute] string name)
        {
            var Staff = await _StaffService.GetStaffByName(name);

            if (Staff == null)
            {
                return NotFound();
            }

            return Staff;
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStaff([FromBody] UpdateStaffRequest updateStaffRequest)
        {
            try
            {
                await _StaffService.UpdateStaff(updateStaffRequest);
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
        public async Task<ActionResult<Staff>> PostStaff([FromBody] CreateStaffRequest createStaffRequest)
        {
            try
            {
                return Ok(await _StaffService.AddNewStaff(createStaffRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] Guid id)
        {
            try
            {
                await _StaffService.DeleteStaff(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("accept_user/{AcceptID}")]
        public async Task<IActionResult> AcceptAccountCreate([FromRoute] Guid AcceptID)
        {
            try
            {
                await _StaffService.AcceptCreateAccount(AcceptID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=212375
        [HttpPut("ban/{BanID}")]
        public async Task<IActionResult> BanUser([FromRoute] Guid BanID)
        {
            try
            {
                await _StaffService.BanUser(BanID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("unban/{UnbanID}")]
        public async Task<IActionResult> UnbanUser([FromRoute] Guid UnbanID)
        {
            try
            {
                await _StaffService.UnbanUser(UnbanID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //private bool StaffExists(Guid id)
        //{
        //    return (_context.Staffs?.Any(e => e.StaffId == id)).GetValueOrDefault();
        //}
    }
}
