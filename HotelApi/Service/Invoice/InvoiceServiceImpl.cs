using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.Service.Invoice
{
    public class InvoiceServiceImpl : IInvoiceService
    {

        private DBContext _context;

        public InvoiceServiceImpl(DBContext context)
        {
            _context = context;
        }

        public bool CreateInvoice(int idReservation, int days, double price)
        {
            try
            {
                InvoiceModel invoice = new InvoiceModel();
                invoice.IdReservation = idReservation;
                invoice.CreateDate = DateTime.Now;
                invoice.Total = days * price;
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<InvoiceModel> GetAllInvoices()
        {
            try
            {
                return _context.Invoices.ToList();
            }
            catch
            {
                return null;
            }
        }

        public InvoiceModel GetInvoiceById(int id)
        {
            try
            {
                var invoice = _context.Invoices.Find(id);
                invoice.Reservation = _context.Reservations.Find(invoice.IdReservation);
                invoice.Reservation.Room = _context.Rooms.Find(invoice.Reservation.RoomId);
                invoice.Reservation.Room.RoomType = _context.RoomsType.Find(invoice.Reservation.Room.RoomTypeId);
                return invoice;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<InvoiceModel> GetInvoiceByMonth(int month)
        {
            try
            {
                return _context.Invoices.Where(i => i.CreateDate.Month == month).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
