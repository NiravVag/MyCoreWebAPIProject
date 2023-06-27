using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Business;
using MyWebAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly IEmployeeAFL _empAFL;

        public EmployeeAPIController(IEmployeeAFL employeeAFL)
        {
            _empAFL = employeeAFL;
        }

        //Add Employee  
        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                await _empAFL.AddEmployee(employee);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Delete Employee  
        [HttpDelete("DeleteEmployee")]
        public bool DeleteEmployee(Employee _object)
        {
            try
            {
                _empAFL.DeleteEmployee(_object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update Employee  
        [HttpPut("UpdateEmployee")]
        public bool UpdateEmployee(Employee _object)
        {
            try
            {
                _empAFL.EditEmployee(_object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //GET All Employee by Id  
        [HttpGet("GetAllEmployeeById")]
        public Object GetAllEmployeeById(int Id)
        {
            var data = _empAFL.GetEmployeeById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Employee  
        [HttpGet("GetAllEmployee")]
        public Object GetAllEmployee()
        {
            var data = _empAFL.GetEmployeeList();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
