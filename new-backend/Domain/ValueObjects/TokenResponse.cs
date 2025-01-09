namespace Domain.ValueObjects
{
    public class TokenResponse
    {
        public string JwtToken { get; private set; }
        public RefreshToken RefreshToken { get; private set; }

        public TokenResponse(string jwtToken, RefreshToken refreshToken)
        {
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
