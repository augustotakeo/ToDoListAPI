using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Model
{
    public class Annotation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime TaskScheduledFor { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
