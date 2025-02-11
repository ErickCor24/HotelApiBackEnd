using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class EmployeeModel
    {
        [Key]
        public int IdEmployee { get; set; } = 0;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName {  get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        public EmployeeModel(int idEmployee, string name, string lastName, string email, string password, string userName)
        {
            this.IdEmployee = idEmployee;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.UserName = userName;
        }
    }
}
