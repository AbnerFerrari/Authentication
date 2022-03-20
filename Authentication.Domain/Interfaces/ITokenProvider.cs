public interface ITokenProvider
{
    public string GenerateToken(User user, string secret);
}