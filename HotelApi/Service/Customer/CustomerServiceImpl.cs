using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.Service.Customer
{
    public class CustomerServiceImpl : ICustomerService
    {

        private readonly DBContext _context;

        public CustomerServiceImpl(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public CustomerModel GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(x => x.IdCustomer == id);
        }

        public void InsertCustomer(CustomerModel customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
