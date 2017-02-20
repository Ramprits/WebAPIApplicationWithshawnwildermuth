

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIApplication.Data;
using WebAPIApplication.Migrations;

namespace WebAPIApplication.Controllers
{

  [Route("api/Employees")]
  public class EmployeesController : Controller
  {

    ILogger<EmployeesController> _logger;
    private readonly CampDbContext _context;
    public EmployeesController(ILogger<EmployeesController> logger ,CampDbContext context)
    {
      _logger = logger;
      _context =context;
    }
    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var employeeWithDepartment = _context.Employees.ToList();
        return Ok(employeeWithDepartment);
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute GET");
        return BadRequest();
      }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee model)
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
    public IActionResult Put([FromBody] Employee model)
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