using System.ComponentModel.DataAnnotations;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Domain.Entities
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(120, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }
        public Guid ListCardId { get; set; }
        public StatusCardEnum Status { get; set; } = StatusCardEnum.Todo;
    }
}
