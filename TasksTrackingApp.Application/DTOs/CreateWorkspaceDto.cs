using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Application.DTOs
{
    public class CreateWorkspaceDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public List<ListCard>? ListCards { get; set; }
        public Guid? UserId { get; set; }
    }
}
