using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class RoomTypeModel
    {
        [Key]
        public int IdRoomType { get; set; } = 0;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; } = 0;

        public RoomTypeModel()
        {
        }

        public RoomTypeModel(int id, string description, double price)
        {
            this.IdRoomType = id;
            this.Description = description;
            this.Price = price;
        }
    }
}
