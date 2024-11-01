namespace TasksTrackingApp.Application.Response
{
    public record ResponseInfo
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int HttpStatus { get; set; }
    }
}
