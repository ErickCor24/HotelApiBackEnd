using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class CustomerModel
    {
        [Key]
        public int IdCustomer { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName {  get; set; } = string.Empty;

        [Required]
        [StringLength(70)]
        public string Email { get; set; } = string.Empty;

        public CustomerModel(int idCustomer, string name, string lastName, string email)
        {
            this.IdCustomer = idCustomer;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
        }

        public CustomerModel() { }
    }
}
