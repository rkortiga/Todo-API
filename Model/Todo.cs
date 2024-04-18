using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo_API.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Task { get; set; }

        public DateOnly CreateDate { get; init; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
