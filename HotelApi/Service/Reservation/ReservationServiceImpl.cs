using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.Service.Reservation
{
    public class ReservationServiceImpl : IReservationService
    {
        DBContext _context;

        public ReservationServiceImpl(DBContext context)
        {
            _context = context;
        }


        public bool CreateReservation(ReservationModel reservation)
        {
            try
            {
                reservation.Status = 1;
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ReservationModel> GetAllReservationOcuped()
        {
            try
            {
                var reservations = _context.Reservations.Where(x => x.Status == 1).ToList();

                foreach (var item in reservations)
                {
                    item.Customer = GetCustomerById(item.CustomerId);
                    item.Room = GetRoomById(item.RoomId);
                }

                return reservations;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ReservationModel GetReservationById(int id)
        {
            try
            {
                return _context.Reservations.Where(x => x.IdReservation == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ChangeReservationStatus(int reservationId)
        {
            try
            {
                var reservation = _context.Reservations.FirstOrDefault(r => r.IdReservation == reservationId);
                if (reservation == null) return false;

                var room = _context.Rooms.FirstOrDefault(r => r.IdRoom == reservation.RoomId);
                if (room == null) return false;
                
                reservation.Status = 0;
                room.Status = 0;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private RoomModel GetRoomById(int idRoom)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.IdRoom == idRoom);
            room.RoomType = _context.RoomsType.SingleOrDefault(x => x.IdRoomType == room.RoomTypeId);
            return room;
        }

        private CustomerModel GetCustomerById(int idCustomer)
        {
            return _context.Customers.FirstOrDefault(x => x.IdCustomer == idCustomer);
        }
    }
}
