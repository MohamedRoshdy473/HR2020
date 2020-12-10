using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using HrAPI.DTO;
using HrAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrAPI.Controllers
{
    
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       // private readonly string email;
        private readonly UserManager<ApplicationUser>userManager;
     //   private readonly Employee CurrentEmpUser;

        public LeaveRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        // GET: api/LeaveRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveDTO>>> GetLeaveRequests()
        {
            return await _context.LeaveRequests.Select(ex => new LeaveDTO
                {
                    ID = ex.ID,
                    EmployeeName = ex.Employee.Name,
                    Profession = ex.Employee.Profession.Name,
                    Status = ex.Status,
                    Comment = ex.Comment,
                    Date = ex.Date,
                    EmployeeID = ex.EmployeeID,
                    AlternativeAddress = ex.AlternativeAddress,
                    AlternativeEmp = ex.AlternativeEmp.Name,
                    Days = ex.Days,
                    LeaveTypeID = ex.LeaveTypeID,
                    Start = ex.Start
                }).ToListAsync();

        }


        // GET: api/LeaveRequests/5
        [HttpGet("{id}")]
        public LeaveDTO GetLeaveRequest(int id)
        {
            var leaveRequest =  _context.LeaveRequests.Include(e=>e.Employee).ThenInclude(e=>e.Profession).Include(e => e.AlternativeEmp)
                .Include(e=>e.LeaveType).FirstOrDefault(e=>e.ID==id);
            var LeaveRequestDTO = new LeaveDTO
            {
                ID = leaveRequest.ID,
                EmployeeName = leaveRequest.Employee.Name,
                Profession = leaveRequest.Employee.Profession.Name,
                Status = leaveRequest.Status,
                End = leaveRequest.Start.AddDays(leaveRequest.Days),
                Comment = leaveRequest.Comment,
                Date = leaveRequest.Date,
                EmployeeID = leaveRequest.EmployeeID,
                AlternativeAddress = leaveRequest.AlternativeAddress,
                AlternativeEmp = leaveRequest.AlternativeEmp.Name,
                Days = leaveRequest.Days,
                LeaveTypeID = leaveRequest.LeaveTypeID,
                Start = leaveRequest.Start
            };
            return LeaveRequestDTO;
        }
        [Route("ApprovedLeaves")]
        public async Task<ActionResult<IEnumerable<LeaveDTO>>> GetApprovedLeaves()
        {
            return await _context.LeaveRequests.Where(ex => ex.Status == "approved").Select(ex => new LeaveDTO
            {
                ID = ex.ID,
                EmployeeName=ex.Employee.Name,
                Profession=ex.Employee.Profession.Name,
                Status = ex.Status,
                Comment = ex.Comment,
                Date = ex.Date,
                EmployeeID = ex.EmployeeID,
                AlternativeAddress = ex.AlternativeAddress,
                AlternativeEmp = ex.AlternativeEmp.Name,
                Days = ex.Days,
                LeaveTypeID = ex.LeaveTypeID,
                Start = ex.Start
            }).ToListAsync();
        }
        [Route("DisApprovedLeaves")]
        public async Task<ActionResult<IEnumerable<LeaveDTO>>> GetDisApprovedLeaves()
        {
            return await _context.LeaveRequests.Where(ex => ex.Status == "disapproved").Select(ex => new LeaveDTO
            {
                ID = ex.ID,
                EmployeeName = ex.Employee.Name,
                Profession = ex.Employee.Profession.Name,
                Status = ex.Status,
                Comment = ex.Comment,
                Date = ex.Date,
                EmployeeID = ex.EmployeeID,
                AlternativeAddress = ex.AlternativeAddress,
                AlternativeEmp = ex.AlternativeEmp.Name,
                Days = ex.Days,
                LeaveTypeID = ex.LeaveTypeID,
                Start = ex.Start

            }).ToListAsync();
        }
        [Route("PendingLeaves")]
        public async Task<ActionResult<IEnumerable<LeaveDTO>>> GetPendingLeaves()
        {
            var R= await _context.LeaveRequests.Where(ex =>
            ex.Start.Date.Year == DateTime.Today.Date.Year
            && ex.Start.Date.Month == DateTime.Today.Date.Month
            &&   ex.Start.Date.Day >= DateTime.Today.Date.Day
           && ex.Status == "pending").Select(ex => new LeaveDTO
            {
                ID = ex.ID,
                EmployeeName = ex.Employee.Name,
                Profession = ex.Employee.Profession.Name,
                Status = ex.Status,
                Comment = ex.Comment,
                Date = ex.Date,
                EmployeeID = ex.EmployeeID,
                AlternativeAddress = ex.AlternativeAddress,
                AlternativeEmp = ex.AlternativeEmp.Name,
                Days = ex.Days,
                LeaveTypeID = ex.LeaveTypeID,
                Start = ex.Start
            }).ToListAsync();
            return R;
        }

        //[HttpGet("{id}")]
        [Route("AcceptLeave/{id}")]
        public ActionResult AcceptLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
            {
                return NotFound();
            }
            leave.Status = "approved";
            _context.SaveChanges();
            return Ok();
        }
        [Route("RejectLeave/{id}")]
        public ActionResult RejectLeave(int id)
        {
            var leave = _context.LeaveRequests.Find(id);

            if (leave == null)
            {
                return NotFound();
            }
            leave.Status = "disapproved";
            _context.SaveChanges();
            return Ok();
        }
        [Route("PreviousLeaves")]
        public async Task<ActionResult<IEnumerable<LeaveDTO>>> PreviousLeaves()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var emp = _context.Employees.Where(e => e.Email == email).FirstOrDefault();

            return await _context.LeaveRequests.Where(ex => ex.Employee.Email == email).Select(ex => new LeaveDTO
            {
                ID = ex.ID,
                EmployeeName = ex.Employee.Name,
                Profession = ex.Employee.Profession.Name,
                Status = ex.Status,
                Comment = ex.Comment,
                Date = ex.Date,
                EmployeeID=ex.EmployeeID,
                AlternativeAddress=ex.AlternativeAddress,
                AlternativeEmp=ex.AlternativeEmp.Name,
                Days=ex.Days,
                LeaveTypeID=ex.LeaveTypeID,
                Start=ex.Start

            }).ToListAsync();
        }

        [HttpGet]
        [Route("getLeaveRequestfiles/{id}")]
        public IEnumerable<string> getLeaveRequestfiles(int id)
        {
            return _context.LeaveFiles.Where(l => l.LeaveRequestID == id).Select(l=>l.FileName).ToList();
        }
        // PUT: api/LeaveRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeaveRequest(int id, LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.ID)
            {
                return BadRequest();
            }

            _context.Entry(leaveRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LeaveRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("AddLeaveRequest")]
        public async Task<ActionResult<LeaveRequest>> PostLeaveRequest(LeaveRequestVM LeaveRequestObj)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var lstUsers = _context.Employees.Where(e => e.Email == email).ToList();
            if (lstUsers.Count > 0)
            {
                var CurrentEmpUser = lstUsers[0];
                if (LeaveRequestObj.EmployeeID == 0)
                {
                    LeaveRequestObj.EmployeeID = CurrentEmpUser.ID;
                }
                LeaveRequestObj.Date = DateTime.Now;
                LeaveRequest lv = new LeaveRequest
                {
                    Date = LeaveRequestObj.Date,
                    Comment = LeaveRequestObj.Comment,
                    AlternativeEmpID = LeaveRequestObj.AlternativeEmpID,
                    EmployeeID = LeaveRequestObj.EmployeeID,
                    LeaveTypeID = LeaveRequestObj.LeaveTypeID,
                    AlternativeAddress = LeaveRequestObj.AlternativeAddress,
                    Start = LeaveRequestObj.Start,
                    Status = LeaveRequestObj.Status,
                    Days = LeaveRequestObj.Days
                };
                _context.LeaveRequests.Add(lv);
                await _context.SaveChangesAsync();

                if (LeaveRequestObj.LeavesFiles != null)
                {
                    var files = LeaveRequestObj.LeavesFiles.Split(',').ToList();

                    files.Remove("");
                    foreach (var item in files)
                    {
                        LeaveFiles leaveFiles = new LeaveFiles
                        {
                            FileName = item,
                            LeaveRequestID = lv.ID
                        };
                        _context.LeaveFiles.Add(leaveFiles);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetLeaveRequest", new { id = LeaveRequestObj.ID }, LeaveRequestObj);
        }

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveRequest>> DeleteLeaveRequest(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();

            return leaveRequest;
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.ID == id);
        }


        //LeavesTypesController------------------------------------------------------------------
        //[HttpGet]
        //[Route("GetLeaveTypes")]
        //public async Task<ActionResult<IEnumerable<LeavesTypes>>> GetLeaveTypes()
        //{
        //    return await _context.LeavesTypes.ToListAsync();
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<LeavesTypes>> GetLeaveType(int id)
        //{
        //    var leavesTypes = await _context.LeavesTypes.FindAsync(id);

        //    if (leavesTypes == null)
        //    {
        //        return NotFound();
        //    }

        //    return leavesTypes;
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLeavesType(int id, LeavesTypes leavesTypes)
        //{
        //    if (id != leavesTypes.ID)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(leavesTypes).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<LeavesTypes>> PostEvaluationType(LeavesTypes leavesType)
        //{
        //    _context.LeavesTypes.Add(leavesType);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEvaluationType", new { id = leavesType.ID }, leavesType);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<LeavesTypes>> DeleteLeavesType(int id)
        //{
        //    var LeavesType = await _context.LeavesTypes.FindAsync(id);
        //    if (LeavesType == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.LeavesTypes.Remove(LeavesType);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LeavesTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return LeavesType;
        //}

        //private bool LeavesTypeExists(int id)
        //{
        //    return _context.LeavesTypes.Any(e => e.ID == id);
        //}










    }
}
