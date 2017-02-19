using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Data;
using WebAPIApplication.Infrastructure;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : Controller
    {
        private readonly ICampRepository _repo;
        private readonly CampDbContext _context;
        public CampsController(ICampRepository repo,CampDbContext context)
        {
          _repo = repo;  
          _context = context;
        }
         [HttpGet]
        public IActionResult Get()
        {
            var camp = _context.Camps.ToList();
            if(camp == null)
            return NotFound();
            return Ok(camp);
        }

        
    }
}