using HotelApi.Data;
using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.Customer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {

        private ICustomerService _customerService;

        public CustomerController(ICustomerService customer)
        {
            _customerService = customer;
        }

        [HttpGet]
        public JsonResult GetAllCustomers()
        {
            ResponseDTO response;
            try
            {
                var customers = _customerService.GetAllCustomers();
                if (customers == null) throw new Exception("Don't exist customers in the system");
                response = new ResponseDTO(true, string.Empty, customers);
                return new JsonResult(response);
            }
            catch (Exception e)
            {
                response = new ResponseDTO(false, e.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpGet("{id}")]
        public JsonResult GetCustomerById(int id)
        {
            ResponseDTO response;
            try
            {
                var customer = _customerService.GetCustomerById(id);
                if (customer == null) throw new Exception("Don't found results, customer equals null");
                response = new ResponseDTO(true, string.Empty, customer);
                return new JsonResult(response);
            }
            catch (Exception e)
            {
                response = new ResponseDTO(false, e.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpPost]
        public JsonResult InsertCustomer([FromBody] CustomerModel customer)
        {
            ResponseDTO response;
            try
            {
                _customerService.InsertCustomer(customer);
                response = new ResponseDTO(true, string.Empty, customer);
                return new JsonResult(response);
            }
            catch (Exception e)
            {
                response = new ResponseDTO(false, e.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpPut("{id}")]
        public JsonResult UpdateCustomer(int id, [FromBody] CustomerModel customer)
        {
            ResponseDTO response;
            customer.IdCustomer = id;
            try
            {
                _customerService.UpdateCustomer(customer);
                response = new ResponseDTO(true, string.Empty, customer);
                return new JsonResult(response);
            }
            catch (Exception e)
            {
                response = new ResponseDTO(false, e.Message, null);
                return new JsonResult(response);
            }
        }

    }
}
