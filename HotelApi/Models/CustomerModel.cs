using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class CustomerModel
    {
        [Key]
        public int IdCustomer { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName {  get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        public string Ci { get; set; }

        public int Age { get; set; }

    }
}
