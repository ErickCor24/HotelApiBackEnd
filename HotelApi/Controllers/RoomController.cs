using Azure;
using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public JsonResult InsertRoom([FromBody] int typeRoomId)
        {
            ResponseDTO response;
            try
            {
                if(!_roomService.InsertRoom(typeRoomId)) throw new Exception("New room not has created");
                response = new ResponseDTO(true, "New room has created", typeRoomId);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(true, ex.Message, null);
                return new JsonResult(response);
            }
        }

        [HttpGet("{idRoom}")]
        public JsonResult GetRoomById(int idRoom)
        {
            ResponseDTO response;
            try
            {
                var room = _roomService.GetRoomById(idRoom);
                if (room == null) throw new Exception("Room don´t found");
                response = new ResponseDTO(true, "Room found", room);
                return new JsonResult(response);

            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpGet("{idRoomType}")]
        public JsonResult GetTypeRooms(int idRoomType)
        {
            ResponseDTO response;
            try
            {
                var roomsByType = _roomService.GetTypeRooms(idRoomType);
                if (roomsByType.Count() <= 0) throw new Exception("Don´t exist that rooms type");
                response = new ResponseDTO(true, "Rooms were found", roomsByType);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpGet]
        public JsonResult GetAllRooms()
        {
            ResponseDTO response;
            try
            {
                var allRooms = _roomService.GettAllRooms();
                if (allRooms.Count() <= 0) throw new Exception("Don´t exist rooms");
                response = new ResponseDTO(true, "Rooms were found", allRooms);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpPut("{idRoom}")]
        public JsonResult ChangeRoomStatus(int idRoom, int status)
        {
            ResponseDTO response;
            try
            {

                if (status != 0 && status != 1) throw new Exception("Status is not avalible");
                if (!_roomService.ChangeRoomStatus(idRoom, status)) throw new Exception("Error has ocurred");

                response = new ResponseDTO(true, "Change status was succesfull", status);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, "Change status was not succesfull - " + ex.Message, status);
                return new JsonResult(response);
            }
        }


        [HttpPut("{idRoom}")]
        public JsonResult UpdateRoomData(int idRoom, [FromBody] RoomModel room)
        {
            ResponseDTO response;
            room.IdRoom = idRoom;
            try
            {
                _roomService.UpdateRoomData(room);
                response = new ResponseDTO(true, "Change data succesfull", room);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }
    }
}
