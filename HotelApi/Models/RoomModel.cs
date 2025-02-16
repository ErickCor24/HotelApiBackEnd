
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    public class RoomModel
    {
        [Key]
        public int IdRoom { get; set; }

        [ForeignKey("RoomType")]
        public int RoomTypeId { get; set; }

        public RoomTypeModel? RoomType { get; set; }

        [Required]
        public int Status { get; set; }

    }
}
