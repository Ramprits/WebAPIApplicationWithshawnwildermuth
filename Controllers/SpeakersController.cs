
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPIApplication.Data;
using WebAPIApplication.Entities;

namespace WebAPIApplication.Controllers
{

  [Route("api/Speakers")]
  public class SpeakersController : Controller
  {

    ILogger<SpeakersController> _logger;
    private readonly CampDbContext _context;

    public SpeakersController(ILogger<SpeakersController> logger,CampDbContext context)
    {
      _logger = logger;
      _context =context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var speakers = _context.Speakers.ToList();
        return Ok(speakers);
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute GET");
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Speaker model)
    {
      try
      {
        return Created("", null);
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute POST");
        return BadRequest();
      }
    }

    [HttpPut]
    public IActionResult Put([FromBody] Speaker model)
    {
      try
      {
        return Ok();
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute PUT");
        return BadRequest();
      }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      try
      {
        return Ok();
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute DELETE");
        return BadRequest();
      }
    }
  }
}