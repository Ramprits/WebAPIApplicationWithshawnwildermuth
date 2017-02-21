
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPIApplication.Data;
using WebAPIApplication.Entities;
using WebAPIApplication.Infrastructure;

namespace WebAPIApplication.Controllers
{

  [Route("api/Departments")]
  public class DepartmentsController : Controller
  {

    ILogger<DepartmentsController> _logger;

    private readonly CampDbContext _context;

    private GenericRepository<Department> _repo;
    public DepartmentsController(ILogger<DepartmentsController> logger ,
    CampDbContext context,GenericRepository<Department> repo)
    {
      _repo = repo;
      _logger = logger;
      _context =context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        return Ok(_repo.All);
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute GET");
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Department  model)
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
    public IActionResult Put([FromBody] Department   model)
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