using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Context;
using UniversityAPI.Models;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly MssqlContext _context;

        public ExamController(MssqlContext context)
        {
            _context = context;
        }

        // GET: api/Exam
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var models = await _context.Exams
                .Include(exam => exam.Student)
                .Include(exam => exam.Subject)
                .ToListAsync();

            return new JsonResult(models);
        }

        // GET api/Exam/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int id)
        {
            var model = await _context.Exams
                .Include(exam => exam.Student)
                .Include(exam => exam.Subject)
                .FirstOrDefaultAsync(exam => exam.Id == id);

            return new JsonResult(model);
        }

        // POST api/Exam
        [HttpPost]
        public async Task<JsonResult> Create(Exam model)
        {
            var addedModel = await _context.Exams.AddAsync(model);
            await _context.SaveChangesAsync();
            return new JsonResult(addedModel);
        }

        // PUT api/Exam/5
        [HttpPut]
        public async Task<JsonResult> Update(Exam model)
        {
            var updatedModel = _context.Exams.Update(model);
            await _context.SaveChangesAsync();
            return new JsonResult(updatedModel);
        }

        // DELETE api/Exam/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var modelToDelete = await _context.Exams.FindAsync(id);
            var removedModel = _context.Exams.Remove(modelToDelete);
            await _context.SaveChangesAsync();
            return new JsonResult(removedModel);
        }
    }
}
