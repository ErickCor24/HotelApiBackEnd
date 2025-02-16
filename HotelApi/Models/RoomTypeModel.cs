using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class RoomTypeModel
    {
        [Key]
        public int IdRoomType { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }
    }
}
