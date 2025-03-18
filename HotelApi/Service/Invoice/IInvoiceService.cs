using HotelApi.Models;

namespace HotelApi.Service.Invoice
{
    public interface IInvoiceService
    {

        bool CreateInvoice(int idReservation, int days, double price);

        IEnumerable<InvoiceModel> GetAllInvoices();

        InvoiceModel GetInvoiceById(int id);

        IEnumerable<InvoiceModel> GetInvoiceByMonth(int month);
    }
}
