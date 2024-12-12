using System.Text.Json.Serialization;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Application.DTOs
{
    public class ListCardDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public StatusItemEnum Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid WorkspaceId { get; set; }

        [JsonIgnore]
        public ICollection<Card> Cards { get; set; }
    }
}
