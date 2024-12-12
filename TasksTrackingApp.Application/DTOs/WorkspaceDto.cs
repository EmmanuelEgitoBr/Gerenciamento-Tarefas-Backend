using System.Text.Json.Serialization;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.DTOs
{
    public class WorkspaceDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public List<ListCard>? ListCards { get; set; }
        
        [JsonIgnore]
        public Guid? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
