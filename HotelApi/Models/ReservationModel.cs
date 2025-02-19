using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class ReservationModel
    {
        [Key]
        public int IdReservation { get; set; } = 0;


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public CustomerModel? Customer { get; set; }


        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public RoomModel? Room { get; set; }

        [Required]
        public int Status { get; set; }

    }
}
