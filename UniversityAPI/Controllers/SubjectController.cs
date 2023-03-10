using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityAPI.Context;
using UniversityAPI.Models;

namespace UniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly MssqlContext _context;

        public SubjectController(MssqlContext context)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var models = await _context.Subjects.ToListAsync();
            return new JsonResult(models);
        }

        // GET api/Subject/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetById(int id)
        {
            var model = await _context.Subjects.FindAsync(id);
            return new JsonResult(model);
        }

        // POST api/Subject
        [HttpPost]
        public async Task<JsonResult> Create(Subject model)
        {
            var addedModel = await _context.Subjects.AddAsync(model);
            await _context.SaveChangesAsync();
            return new JsonResult(addedModel);
        }

        // PUT api/Subject/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Update(Subject model)
        {
            var updatedModel = _context.Subjects.Update(model);
            await _context.SaveChangesAsync();
            return new JsonResult(updatedModel);
        }

        // DELETE api/Subject/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var modelToDelete = await _context.Subjects.FindAsync(id);
            var deletedModel = _context.Subjects.Remove(modelToDelete);
            await _context.SaveChangesAsync();
            return new JsonResult(deletedModel);
        }
    }
}
