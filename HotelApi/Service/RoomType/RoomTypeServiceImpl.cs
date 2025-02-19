using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.Service.RoomType
{
    public class RoomTypeServiceImpl : IRoomTypeService
    {
        private readonly DBContext _context;

        public RoomTypeServiceImpl(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomTypeModel> GetRoomTypes()
        {
            return _context.RoomsType.ToList();
        }

        public bool InsertNewRoomType(RoomTypeModel roomType)
        {
            try
            {
                _context.RoomsType.Add(roomType);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditRoomTypeById(int id, RoomTypeModel roomType)
        {
            roomType.IdRoomType = id;
            try
            {
                _context.RoomsType.Update(roomType);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}