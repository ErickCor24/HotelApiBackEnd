using HotelApi.Data;
using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public JsonResult GetAllEmployees()
        {
            ResponseDTO response;
            try
            {
                var employees = employeeService.GetAllEmployees();
                if (employees == null) throw new Exception("User don't found");
                response = new ResponseDTO(true, string.Empty, employees);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpPost("[action]")]
        public JsonResult InsertEmploye([FromBody] EmployeeModel employee)
        {
            ResponseDTO response ;
            try
            {
                employeeService.RegisterEmploye(employee);
                response = new ResponseDTO(true, string.Empty, employee);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpPost]
        public JsonResult GetCustomerByAuthentication([FromBody] AuthenticationDTO authentication)
        {
            ResponseDTO response;
            try
            {
                var employee = employeeService.GetEmployee(authentication);
                if (employee == null) throw new Exception("User account don't found");
                response = new ResponseDTO(true, "Employee account found", employee);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }
    }
}
