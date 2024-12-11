using System.Text.Json.Serialization;

namespace TasksTrackingApp.Application.DTOs
{
    public record UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        
        [JsonIgnore]
        public string Token { get; set; } = string.Empty;

        [JsonIgnore]
        public string RefreshToken { get; set; } = string.Empty;
        
        [JsonIgnore]
        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
