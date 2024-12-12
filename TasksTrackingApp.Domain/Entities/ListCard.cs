using TasksTrackingApp.Domain.Enums;

namespace TasksTrackingApp.Domain.Entities
{
    public class ListCard
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public StatusItemEnum Status { get; set; } = StatusItemEnum.Ativo;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public Guid WorkspaceId { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
