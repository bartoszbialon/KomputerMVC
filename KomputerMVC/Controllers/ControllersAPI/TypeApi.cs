using Data;
using Microsoft.AspNetCore.Mvc;

namespace KomputerMVC.Controllers.ControllersAPI
{
    [Route("api/types")]
    [ApiController]
    public class TypeApi : ControllerBase
    {
        private readonly AppDbContext _context;
        public TypeApi(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAllTypes()
        {
            var types = _context.Types.Select(o => new { id = o.TypeId, TypeName = o.TypeName }).ToList();
            return Ok(types);
        }
    }
}
