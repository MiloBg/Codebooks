using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Codebooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupMasterController : ControllerBase
    {
        private readonly DataContext _context;

        public LookupMasterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LookupMaster>>> Get()
        {
            return Ok(await _context.LookupMasters.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<LookupMaster>>> Create(LookupMaster request)
        {
            _context.LookupMasters.Add(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.LookupMasters.ToListAsync());
        }
    }
}
