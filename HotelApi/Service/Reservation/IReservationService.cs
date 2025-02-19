using HotelApi.Data;
using HotelApi.Models;

namespace HotelApi.Service.Reservation
{
    public interface IReservationService
    {
        Boolean CreateReservation(ReservationModel reservation);

        IEnumerable<ReservationModel> GetAllReservationOcuped();

        Boolean ChangeReservationStatus(int reservationId);
    }
}
