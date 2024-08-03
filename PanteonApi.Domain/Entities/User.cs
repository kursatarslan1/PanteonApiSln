using System.ComponentModel.DataAnnotations;
namespace PanteonApi.Domain.Entities{
    
    public class User{
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}