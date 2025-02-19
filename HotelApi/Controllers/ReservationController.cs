using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.Reservation;
using HotelApi.Service.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        IReservationService _reservationService;
        IRoomService _roomService;

        public ReservationController(IReservationService reservationService, IRoomService roomService)
        {
            _reservationService = reservationService;
            _roomService = roomService;
        }

        [HttpPost]
        public JsonResult CreateReservation([FromBody] ReservationModel reservation)
        {
            ResponseDTO response;
            try
            {
                if (_roomService.CheckRoomStatusById(reservation.RoomId)) throw new Exception("Failed to create the new reservation, the room is at use");
                if (!_reservationService.CreateReservation(reservation)) throw new Exception("Failed to create the new reservation");
                response = new ResponseDTO(true, "Reservation created successfully", reservation);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpGet]
        public JsonResult GetAllReservationOcuped()
        {
            ResponseDTO response;
            try
            {
                var reservations = _reservationService.GetAllReservationOcuped();
                if (reservations.Count() <= 0) throw new Exception("Don't exist reservations");
                response = new ResponseDTO(true, "Reservations obtained successfully", reservations);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }


        [HttpPut("{reservationId}")]
        public JsonResult ChangeReservationStatus(int reservationId)
        {
            ResponseDTO response;
            try
            {
                if (!_reservationService.ChangeReservationStatus(reservationId)) throw new Exception("Failed to change the reservation status");
                response = new ResponseDTO(true, "Reservation status changed successfully", null);
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
