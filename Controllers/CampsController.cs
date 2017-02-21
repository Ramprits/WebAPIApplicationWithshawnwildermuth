using System;
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

            var campWithSpeaker = _context.Speakers.Join(_context.Camps,
                                    s => s.CampId,
                                    c => c.Id
                                    ,(speaker,cam) =>
                                    new{
                                            Name = speaker.Name,
                                            TwitterName = speaker.TwitterName,
                                            CampName = cam.Description
                                        }
                                    );


            if(camp == null)
            return NotFound();
            return Ok(campWithSpeaker);
        }


        [HttpGet("{Id}")]
        public IActionResult Get(int? Id)
        {
          try
          {
              if (Id == null)
              {
                 return NotFound($"Speaker with Id {Id} not found "); 
              }
            var CampById = _context.Camps.Where(x => x.Id == Id).FirstOrDefault();
            if (CampById == null) return BadRequest($"This is bad request {CampById}");

            return Ok(CampById);
          }
          catch (Exception )
          {
            return BadRequest();
          }
        }

        
    }
}