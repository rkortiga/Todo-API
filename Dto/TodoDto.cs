using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo_API.Dto
{
    public class TodoDto
    {
        [Required]
        [MaxLength(255)]
        public string Task { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
