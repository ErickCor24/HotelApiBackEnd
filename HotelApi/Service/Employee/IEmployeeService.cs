using HotelApi.Models;
using HotelApi.Models.DTO;

namespace HotelApi.Service.Employee
{
    public interface IEmployeeService
    {

        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployee(AuthenticationDTO authentication);

        void RegisterEmploye(EmployeeModel employee);
    }
}
