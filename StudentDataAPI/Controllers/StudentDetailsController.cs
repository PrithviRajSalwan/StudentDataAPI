using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentDataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {

        #region CRUD directly to database--Unused 


        private readonly StudentDetailContext _context;

        public StudentDetailsController(StudentDetailContext context)
        {
            _context = context;
        }

        // GET: api/StudentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDetail>>> GetStudentDetail()
        {
            return await _context.StudentDetail.ToListAsync();
        }

        // GET: api/StudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetail>> GetStudentDetail(int id)
        {
            var studentDetail = await _context.StudentDetail.FindAsync(id);

            if (studentDetail == null)
            {
                return NotFound();
            }

            return studentDetail;
        }

        // PUT: api/StudentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetail(int id, StudentDetail studentDetail)
        {
            if (id != studentDetail.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(id))
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

        // POST: api/StudentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDetail>> PostStudentDetail(StudentDetail studentDetail)
        {
            _context.StudentDetail.Add(studentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDetail", new { id = studentDetail.StudentId }, studentDetail);
        }



        //// POST: api/StudentDetails
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public ActionResult CreateStd(String ID)
        //{
        //    return Json("working" + ID); 
        //    //_context.StudentDetail.Add(studentDetail);

        //    //return CreatedAtAction("GetStudentDetail", new { id = studentDetail.StudentId }, studentDetail);
        //}

        private ActionResult Json(string v)
        {
            throw new NotImplementedException();
        }






        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDetail(int id)
        {
            var studentDetail = await _context.StudentDetail.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            _context.StudentDetail.Remove(studentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDetailExists(int id)
        {
            return _context.StudentDetail.Any(e => e.StudentId == id);
        }

        #endregion
    }
}
