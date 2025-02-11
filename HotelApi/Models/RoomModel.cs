
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class RoomModel
    {
        [Key]
        public int IdRoom { get; set; } = 0 ;

        [Required]
        public RoomTypeModel? RoomType { get; set; } = null;

        [Required]
        public int Status { get; set; } = 1;

        public RoomModel()
        {
        }

        public RoomModel(int idRoom, RoomTypeModel roomType, int status = 1)
        {
            this.IdRoom = idRoom;
            this.RoomType = roomType;
            this.Status = status;
        }
    }
}
