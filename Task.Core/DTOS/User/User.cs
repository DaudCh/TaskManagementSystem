using System.ComponentModel.DataAnnotations;

namespace TaskI.Core.DTOS.User
{
    
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

  
    public class UserCreateDTO
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } 
    }

   
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; } 

        [Required]
        public string Role { get; set; }
    }

   
    public class UserDeleteDTO
    {
        [Required]
        public int Id { get; set; }
    }

    
    public class UserLoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
