using System.ComponentModel.DataAnnotations;

public class Entity
    {
        public long Id { get; set; }

        [Required]
        public DateTime InsertionDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }