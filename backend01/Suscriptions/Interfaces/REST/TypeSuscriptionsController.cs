using backend01.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend01.Suscriptions.Interfaces.REST.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend01.Suscriptions.Interfaces.REST
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TypeSuscriptionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeSuscriptionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _context.TypeSuscriptions
                .Select(t => new TypeSuscriptionResource
                {
                    Id = t.Id,
                    Name = t.Name,
                    Costo = t.Costo
                })
                .ToListAsync();

            return Ok(types);
        }
    }
}
