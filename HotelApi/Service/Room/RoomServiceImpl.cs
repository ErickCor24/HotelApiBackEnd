using HotelApi.Data;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Service.Room
{
    public class RoomServiceImpl : IRoomService
    {

        private readonly DBContext _context;

        public RoomServiceImpl(DBContext context)
        {
            _context = context;
        }
        public bool InsertRoom(int newRoomType)
        {
            RoomModel newRoom = new RoomModel();
            newRoom.RoomTypeId = newRoomType;
            try
            {
                _context.Rooms.Add(newRoom);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IEnumerable<RoomModel> GettAllRooms()
        {
            var rooms = _context.Rooms.ToList();
            foreach (var room in rooms)
            {
                room.RoomType = GetRoomTypeById(room.RoomTypeId);
            }
            return rooms;
        }

        public IEnumerable<RoomModel> GetTypeRooms(int roomTypeId)
        {
            var roomsForType = _context.Rooms.Where(x => x.RoomType.IdRoomType == roomTypeId).ToList();

            foreach (var room in roomsForType)
            {
                room.RoomType = GetRoomTypeById(room.RoomTypeId);
            }

            return roomsForType;
        }

        public RoomModel GetRoomById(int idRoom)
        {
            var room = _context.Rooms.FirstOrDefault(x => x.IdRoom == idRoom);
            if (room == null)  return null;
            room.RoomType = GetRoomTypeById(room.RoomTypeId);
            return room;
        }

        public bool ChangeRoomStatus(int idRoom, int status)
        {
            var roomUpdate = GetRoomById(idRoom);
            if (roomUpdate == null) return false;
            roomUpdate.Status = status;
            _context.Rooms.Update(roomUpdate);
            _context.SaveChanges();
            return true;
        }

        public void UpdateRoomData(RoomModel roomUpdate)
        {
            _context.Rooms.Update(roomUpdate);
            _context.SaveChanges();
        }

        private RoomTypeModel GetRoomTypeById(int roomTypeId)
        {
            return _context.RoomsType.FirstOrDefault(x => x.IdRoomType == roomTypeId);
        }
    }
}
