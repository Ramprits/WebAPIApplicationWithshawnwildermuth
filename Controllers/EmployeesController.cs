

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIApplication.Data;
using WebAPIApplication.Entities;
using WebAPIApplication.Infrastructure;

namespace WebAPIApplication.Controllers
{

  [Route("api/Employee")]
  public class EmployeesController : Controller
  {

    ILogger<EmployeesController> _logger;
    private readonly CampDbContext _context;

    private GenericRepository<Employee> _repo;
    public EmployeesController(ILogger<EmployeesController> logger ,
    CampDbContext context,GenericRepository<Employee> repo)
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
        var employeeWithDepartment = _repo.All;
        return Ok(employeeWithDepartment);
      }
      catch (Exception)
      {
        _logger.LogError("Failed to execute GET");
        return BadRequest();
      }
    }

    [HttpGet("{Id}")]
    public IActionResult Get(int Id)
    {
      try
      {
        var employee = _context.Employees.FirstOrDefault(c=>c.Id == Id);
        if (employee == null)
        {
          return BadRequest("Employee Not Found ! ");
        }
        return Ok(employee);
      }
      catch (Exception)
      {
        return BadRequest();
      }
    }
    [HttpPost]
    public IActionResult Post([FromBody] Employee model)
    {
      try
      {
        if(ModelState.IsValid)
        _context.Employees.Add(model);
        _context.SaveChanges();
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