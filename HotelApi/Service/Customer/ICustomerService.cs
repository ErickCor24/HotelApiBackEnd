using HotelApi.Models;

namespace HotelApi.Service.Customer
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerModel> GetAllCustomers();

        public CustomerModel GetCustomerById(int id);

        void InsertCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
    }
}
