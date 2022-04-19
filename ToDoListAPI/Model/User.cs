using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool Checked { get; set; }

        public virtual List<Annotation>? Annotations { get; set; }
    }
}
