using System.ComponentModel.DataAnnotations;

namespace Services.WebApp01.Models
{
    public class WorkTask
    {
        public int TaskId { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}