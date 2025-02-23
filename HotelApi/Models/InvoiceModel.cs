
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class InvoiceModel
    {
        [Key]
        public int IdInvoice { get; set; } = 0 ;

        [ForeignKey("Reservation")]
        public int IdReservation { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public ReservationModel? Reservation { get; set; } 

        public double Total { get; set; }


    }
}
