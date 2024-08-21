using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace EmployeesBackEndApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        private List<Student> Students;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            Students = populateStudent();

        }

        [HttpGet(Name = "GetStudent")]
        public IEnumerable<Student> Get()
        {
            return Students;
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        public int Delete([FromRoute] int id)
        {
            var student = Students.FirstOrDefault(x => x.CustomerId == id);
            if (student != null) Students.Remove(student);
            return id;
        }

        [HttpPost]
        public int AddEmployee([FromBody] Student employee)
        {
            Students.Add(employee);
            return employee.CustomerId;
        }

        List<Student> populateStudent()
        {
            return new List<Student>
            {
                new Student
                {
                    CustomerId = 100,
                    FirstName = "Mohamed",
                    LastName = "Fayaz",
                    Email = "mdfay82@gmail.com",
                    phone = 1,
                    Address="Dubai"
                },
                new Student
                {

                    CustomerId = 100,
                    FirstName = "Mohamed",
                    LastName = "Fayaz",
                    Email = "mdfay82@gmail.com",
                    phone = 1,
                    Address="Dubai"
                }
               
            };
        }

    }

    public class Student
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [EmailAddress]
        [Remote(action: "VerifyEmail", controller: "UserController", ErrorMessage = "Email already in use")]
        [Column("email", TypeName = "varchar(254)")]
        public string Email { get; set; }
        public int phone { get; set; }
        public string? Address { get; set; }
    }

}