using Authentication.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class User : Entity
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    public Role Role { get; set; }
}