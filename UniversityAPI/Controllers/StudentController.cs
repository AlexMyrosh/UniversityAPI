using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Context;
using UniversityAPI.Models;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MssqlContext _context;

        public StudentController(MssqlContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var models = await _context.Students.ToListAsync();
            return new JsonResult(models);
        }

        // GET api/Student/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int id)
        {
            var model = await _context.Students.FindAsync(id);
            return new JsonResult(model);
        }

        // POST api/Student
        [HttpPost]
        public async Task<JsonResult> Create(Student model)
        {
            var addedModel = await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
            return new JsonResult(addedModel);
        }

        // PUT api/Student/5
        [HttpPut]
        public async Task<JsonResult> Update(Student model)
        {
            var updatedModel = _context.Students.Update(model);
            await _context.SaveChangesAsync();
            return new JsonResult(updatedModel);
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var modelToDelete = await _context.Students.FindAsync(id);
            var deletedModel = _context.Students.Remove(modelToDelete);
            await _context.SaveChangesAsync();
            return new JsonResult(deletedModel);
        }
    }
}
