namespace TasksTrackingApp.Domain.Abstractions
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string email, string userName);
        public string GenerateRefreshToken();
        public string HashingPassword(string password);
        public bool CheckUniqueUserAndEmail(string email, string userName);
    }
}
