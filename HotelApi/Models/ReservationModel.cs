using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class ReservationModel
    {
        [Key]
        public int IdReservation { get; set; } = 0;

        [Required]
        public CustomerModel? customer { get; set; } = null;

        [Required]
        public RoomModel? Room { get; set; } = null ;

        public ReservationModel()
        {
        }

        public ReservationModel(int idReservation, CustomerModel customer, RoomModel room)
        {
            this.IdReservation = idReservation;
            this.customer = customer;
            this.Room = room;
        }
    }
}
