namespace TasksTrackingApp.Application.Response
{
    public record ResponseBase<T>
    {
        public string? Title { get; set; }
        public int HttpStatus { get; set; }
        public T? Value { get; set; }
    }
}
