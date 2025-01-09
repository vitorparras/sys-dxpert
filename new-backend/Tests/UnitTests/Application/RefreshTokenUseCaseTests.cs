using Moq;

namespace UnitTests.Application
{
    public class RefreshTokenUseCaseTests
    {
        /*      [Fact]
              public async Task ExecuteAsync_WithValidRefreshToken_ReturnsNewTokens()
              {
                  // Arrange
                  var refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
                  var authServiceMock = new Mock<IAuthService>();
                  var userRepositoryMock = new Mock<IUserRepository>();

                  // var user = new User("test@example.com", "hashedPassword", Role.User);
                  //var refreshToken = new RefreshToken { Token = "validRefreshToken", UserId = user.Id, ExpiresAt = DateTime.UtcNow.AddDays(7) };

                  // refreshTokenRepositoryMock.Setup(r => r.GetByTokenAsync("validRefreshToken")).ReturnsAsync(refreshToken);
                  //  userRepositoryMock.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(user);
                  //  authServiceMock.Setup(s => s.GenerateJwtToken(user)).Returns("newJwtToken");
                  //  authServiceMock.Setup(s => s.GenerateRefreshToken(user)).Returns(new RefreshToken { Token = "newRefreshToken", ExpiresAt = DateTime.UtcNow.AddDays(7) });

                  var useCase = new RefreshTokenUseCase(refreshTokenRepositoryMock.Object, authServiceMock.Object, userRepositoryMock.Object);

                  // Act
                  var result = await useCase.ExecuteAsync("validRefreshToken");

                  // Assert
                  Assert.NotNull(result);
                  Assert.Equal("newJwtToken", result.Token);
                  Assert.Equal("newRefreshToken", result.RefreshToken);
              }

              [Fact]
              public async Task ExecuteAsync_WithInvalidRefreshToken_ThrowsUnauthorizedAccessException()
              {
                  // Arrange
                  var refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
                  var authServiceMock = new Mock<IAuthService>();
                  var userRepositoryMock = new Mock<IUserRepository>();

                  refreshTokenRepositoryMock.Setup(r => r.GetByTokenAsync("invalidRefreshToken")).ReturnsAsync((RefreshToken)null);

                  var useCase = new RefreshTokenUseCase(refreshTokenRepositoryMock.Object, authServiceMock.Object, userRepositoryMock.Object);

                  // Act & Assert
                  await Assert.ThrowsAsync<UnauthorizedAccessException>(() => useCase.ExecuteAsync("invalidRefreshToken"));
              }
          }*/
    }
}
