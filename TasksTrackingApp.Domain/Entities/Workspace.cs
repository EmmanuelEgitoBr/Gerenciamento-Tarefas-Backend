using System.ComponentModel.DataAnnotations;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Domain.Entities
{
    public class Workspace
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public User? User { get; set; }
        public ICollection<ListCard>? ListCards { get; set; }
        public StatusItemEnum Status { get; set; } = StatusItemEnum.Active;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
