using Azure;
using CRUDWebAPI.Data;
using CRUDWebAPI.DTO;
using CRUDWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CRUDWebAPI.Controllers
{
    //localhost:xxxx/api/employees
    //naglagay tayo ng [action] para magamit siya sa mvc core web app natin
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Add CRUD operations

        //get is of course, get
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            { 
                return NotFound(employee);
            }
            return Ok(employee);
        }

        //post is create
        //Note na kapag ganitong mga HttpPost, gagamit ka ng _context.Entity.Add()
        //yang Add(), nag-aaccept lang yan ng mga entities
        //hindi naman pwedeng ipasa agad yang mga entities kasi baka hindi naman need lahat ng ibigay niya
        //baka naman need lang ng Name, bakit pa natin ibibigay yung Email, Phone, Salary?
        //so gagamit tayo ng DTO, yung DTO natin dito is yung AddEmployeeDTO
        //wala yang Id property
        //gumamit din tayo ng mapper dito
        //manual mapping yung nangyari
        //yung DTO natin, ginawa nating Employee Entity
        //para maaccess yung Entity, need natin yung ininject na _context
        //tapos yung nagawang entity na hindi naglalaman ng Id, ipapasa sa Add()
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployee)
        {
            var newEmployee = new Employee()
            {
                Name = addEmployee.Name,
                Email = addEmployee.Email,
                Phone = addEmployee.Phone,
                Salary = addEmployee.Salary
            };
            _context.Employees.Add(newEmployee);
            //Note yung Add() is hindi pa binding, need natin irun yung SaveChanges() para ma-add talaga yung information sa database
            _context.SaveChanges();
            return Ok(newEmployee);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployeeById(Guid id, UpdateEmployeeDTO updateEmployee)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            { 
                return NotFound(employee);
            }
            employee.Name = updateEmployee.Name;   
            employee.Email = updateEmployee.Email;
            employee.Phone = updateEmployee.Phone;
            employee.Salary = updateEmployee.Salary;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployeeById(Guid id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound(employee);
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            //Return the updated list of employees without the deleted employee
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }


        [HttpDelete]
        public IActionResult DeleteAllEmployees()
        { 
            var employees = _context.Employees.ToList();
            if (employees.IsNullOrEmpty())
            {
                return NotFound(employees);
            }
            for (int i = 0; i < employees.Count; i++)
            { 
                _context.Employees.Remove(employees[i]);
                _context.SaveChanges();
            }

            return Ok(employees);
        }
    }
}
