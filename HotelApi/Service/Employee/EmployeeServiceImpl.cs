
using System.Text;
using HotelApi.Data;
using HotelApi.Models;
using HotelApi.Models.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System.IO;
using System.Security.Cryptography;
using HotelApi.Service.Encrypt;

namespace HotelApi.Service.Employee
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly DBContext _context;

        /*CONSTRUCTOR*/
        public EmployeeServiceImpl(DBContext context)
        {
            _context = context;
        }


        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            foreach (var employee in employees)
            {
                employee.Password = EncryptPassword.Decrypt(employee.Password);
            }
            return employees;
        }


        public EmployeeModel GetEmployee(AuthenticationDTO authentication)
        {
            authentication.Password = EncryptPassword.Encrypt(authentication.Password);
            return _context.Employees.FirstOrDefault(x =>
                x.Email == authentication.Email && x.Password == authentication.Password);
        }


        public void RegisterEmploye(EmployeeModel employee)
        {
            employee.Password = EncryptPassword.Encrypt(employee.Password);
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

    }
}
