using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.RoomType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {

        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this._roomTypeService = roomTypeService;
        }


        [HttpPost]
        public JsonResult InsertRoomType([FromBody] RoomTypeModel roomType)
        {
            ResponseDTO response;
            try
            {
                if (!_roomTypeService.InsertNewRoomType(roomType)) throw new Exception("An error has ocurred to try create a new room type");
                response = new ResponseDTO(true, "Room type succesfull created", roomType);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpGet]
        public JsonResult GetAllRoomTypes()
        {
            ResponseDTO response;
            try
            {
                var roomsType = _roomTypeService.GetRoomTypes();
                if (roomsType.Count() <= 0) throw new Exception("An error has ocurred, dont found rooms type");
                response = new ResponseDTO(true, "Get all type rooms was succesfull", roomsType);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpPut]
        public JsonResult EditRoomTypeById(int id, [FromBody] RoomTypeModel roomType)
        {
            ResponseDTO response;
            try
            {
                if (!_roomTypeService.EditRoomTypeById(id, roomType)) throw new Exception("An error has ocurred to try edit room type");
                response = new ResponseDTO(true, "Room type succesfull edited", roomType);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }
    }
}
