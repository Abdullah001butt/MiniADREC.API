namespace MiniADREC.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
