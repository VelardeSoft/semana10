using backend01.Scooter.Interfaces.REST.Resources;
using backend01.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend01.Scooter.Interfaces.REST
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DistrictsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var districts = await _context.Districts
                .Select(d => new DistrictResource
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();

            return Ok(districts);
        }
    }
}
