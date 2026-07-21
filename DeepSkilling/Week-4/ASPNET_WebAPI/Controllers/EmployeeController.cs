using Microsoft.AspNetCore.Mvc;
using _1.web_api.Models;
using _1.web_api.Filters;

namespace _1.web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[CustomAuthFilter]
public class EmployeeController : ControllerBase
{
    // GET

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> GetStandard()
    {
        return Ok(GetStandardEmployeeList());
    }

    // POST

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        return Ok(employee);
    }

    // PUT

    [HttpPut("{id}")]
    public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var employees = GetStandardEmployeeList();

        var existingEmployee = employees.FirstOrDefault(e => e.Id == id);

        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;
        existingEmployee.Department = employee.Department;
        existingEmployee.Skills = employee.Skills;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        return Ok(existingEmployee);
    }

    // Private Method

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true,
                Department = new Department
                {
                    Id = 101,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "ASP.NET Core" }
                },
                DateOfBirth = new DateTime(1998, 5, 15)
            },
            new Employee
            {
                Id = 2,
                Name = "Alice",
                Salary = 60000,
                Permanent = false,
                Department = new Department
                {
                    Id = 102,
                    Name = "HR"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 3, Name = "Communication" },
                    new Skill { Id = 4, Name = "Recruitment" }
                },
                DateOfBirth = new DateTime(1997, 8, 20)
            }
        };
    }
}