using HotelApi.Models;

namespace HotelApi.Service.RoomType
{
    public interface IRoomTypeService
    {
        bool InsertNewRoomType(RoomTypeModel roomType);

        IEnumerable<RoomTypeModel> GetRoomTypes();
        bool EditRoomTypeById(int id, RoomTypeModel roomType);
    }
}
