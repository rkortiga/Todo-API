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
        public string Task { get; set; }

        public DateOnly CreateDate { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
