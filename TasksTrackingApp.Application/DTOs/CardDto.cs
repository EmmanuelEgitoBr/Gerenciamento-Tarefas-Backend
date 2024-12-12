using System.ComponentModel.DataAnnotations;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.DTOs
{
    public class CardDto
    {
        
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public Guid ListCardId { get; set; }
        public StatusCardEnum Status { get; set; }
    }
}
