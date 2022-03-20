using System.ComponentModel.DataAnnotations;

public class User : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(25)]
        public string Role { get; set; }
    }