namespace IntegrationTests
{
    /*  public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
      {
          private readonly WebApplicationFactory<Program> _factory;

          public AuthControllerTests(WebApplicationFactory<Program> factory)
          {
              _factory = factory;
          }

          [Fact]
          public async Task Register_WithValidData_ReturnsOk()
          {
              // Arrange
              var client = _factory.CreateClient();
              var registerDto = new RegisterUserDto
              {
                  Email = "test@example.com",
                  Password = "StrongPassword123!"
              };

              // Act
              var response = await client.PostAsJsonAsync("/api/auth/register", registerDto);

              // Assert
              Assert.Equal(HttpStatusCode.OK, response.StatusCode);
          }

          [Fact]
          public async Task Login_WithValidCredentials_ReturnsOkWithToken()
          {
              // Arrange
              var client = _factory.CreateClient();
              var loginDto = new LoginRequestDto
              {
                  Email = "test@example.com",
                  Password = "StrongPassword123!"
              };

              // Act
              var response = await client.PostAsJsonAsync("/api/auth/login", loginDto);

              // Assert
              Assert.Equal(HttpStatusCode.OK, response.StatusCode);
              var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
              Assert.NotNull(content?.Token);
              Assert.NotNull(content?.RefreshToken);
          }

          [Fact]
          public async Task RefreshToken_WithValidToken_ReturnsNewToken()
          {
              // Arrange
              var client = _factory.CreateClient();
              var loginDto = new LoginRequestDto
              {
                  Email = "test@example.com",
                  Password = "StrongPassword123!"
              };

              var loginResponse = await client.PostAsJsonAsync("/api/auth/login", loginDto);
              var loginContent = await loginResponse.Content.ReadFromJsonAsync<LoginResponseDto>();

              var refreshTokenDto = new RefreshTokenRequestDto
              {
                  RefreshToken = loginContent.RefreshToken
              };

              // Act
              var response = await client.PostAsJsonAsync("/api/auth/refresh-token", refreshTokenDto);

              // Assert
              Assert.Equal(HttpStatusCode.OK, response.StatusCode);
              var content = await response.Content.ReadFromJsonAsync<LoginResponseDto>();
              Assert.NotNull(content?.Token);
              Assert.NotNull(content?.RefreshToken);
          }

          [Fact]
          public async Task AdminOnly_WithoutAdminRole_ReturnsUnauthorized()
          {
              // Arrange
              var client = _factory.CreateClient();

              // Act
              var response = await client.GetAsync("/api/auth/admin-only");

              // Assert
              Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
          }
      }*/
}
