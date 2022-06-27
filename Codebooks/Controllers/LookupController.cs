using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Codebooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly DataContext _context;

        public LookupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LookupMaster>>> Get()
        {
            return Ok(await _context.LookupMasters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<LookupMaster>>> Get(int id)
        {
            var lookupMasters = await _context.LookupMasters.Where(m => m.Id == id).Include(v => v.LookupValues).ToListAsync();
            return Ok(lookupMasters);
        }

        [HttpPost]
        public async Task<ActionResult<List<LookupMaster>>> Create(LookupMaster request)
        {
            _context.LookupMasters.Add(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.LookupMasters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LookupMaster>>> DeleteLookupMaster(int id)
        {
            var dbLookupMaster = await _context.LookupMasters.FindAsync(id);
            if (dbLookupMaster == null)
            {
                return BadRequest("Lookup not found");
            }
            else
            {
                _context.LookupMasters.Remove(dbLookupMaster);
                await _context.SaveChangesAsync();
                return Ok(await _context.LookupMasters.ToListAsync());
            }
        }
    }
}
