using HotelApi.Models;

namespace HotelApi.Service.Room
{
    public interface IRoomService
    {
        bool InsertRoom(int newRoomType);

        IEnumerable<RoomModel> GettAllRooms();

        IEnumerable<RoomModel> GetTypeRooms(int roomTypeId);

        RoomModel GetRoomById(int idRoom);

        bool ChangeRoomStatus(int idRoom, int status);

        void UpdateRoomData(RoomModel roomUpdate);

        bool CheckRoomStatusById(int RoomId);
    }
}
