using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksTrackingApp.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;

        [StringLength (50, MinimumLength = 3)]
        [Column(TypeName = "nvarchar(50)")]
        public string Surname { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;
        public ICollection<Workspace>? Workspaces { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpirationTime { get; set; }
    }
}
