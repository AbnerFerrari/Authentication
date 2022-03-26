using System.ComponentModel.DataAnnotations;

public class Entity
{
    public long Id { get; set; }

    [Required]
    public DateTime InsertionDate { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }
}