
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class InvoiceModel
    {
        [Key]
        public int IdInvoice { get; set; } = 0 ;

        [Required]
        public ReservationModel? ReservationModel { get; set; } = null;

        [Required]
        public DateTime? CreateDate { get; set; } = DateTime.MinValue;

        public InvoiceModel()
        {
        }

        public InvoiceModel(int idInvoice, ReservationModel reservationModel)
        {
            this.IdInvoice = idInvoice;
            this.ReservationModel = reservationModel;
            this.CreateDate = DateTime.UtcNow;
        }
    }
}
