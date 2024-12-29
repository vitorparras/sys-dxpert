using Application.DTOs;
using Application.UseCases;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Application
{
    public class LoginUserUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_WithValidCredentials_ReturnsLoginResponse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();
            var refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
            var loggerMock = new Mock<ILogger<LoginUserUseCase>>();

            var user = new User(Email.Create("test@example.com"), PasswordHash.Create("hashedPassword"), Role.User);
            userRepositoryMock.Setup(r => r.GetByEmailAsync("test@example.com")).ReturnsAsync(user);
            authServiceMock.Setup(s => s.ValidatePassword("password", "hashedPassword")).Returns(true);
            authServiceMock.Setup(s => s.GenerateJwtToken(user)).Returns("jwtToken");
            authServiceMock.Setup(s => s.GenerateRefreshToken(user)).Returns(new RefreshToken(user, DateTime.UtcNow.AddDays(7)));

            var useCase = new LoginUserUseCase(userRepositoryMock.Object, authServiceMock.Object, refreshTokenRepositoryMock.Object, loggerMock.Object);

            // Act
            var result = await useCase.ExecuteAsync(new LoginRequestDto { Email = "test@example.com", Password = "password" });

            // Assert
            Assert.NotNull(result);
            Assert.Equal("jwtToken", result.Token);
            Assert.NotNull(result.RefreshToken);
        }

        [Fact]
        public async Task ExecuteAsync_WithInvalidCredentials_ThrowsUnauthorizedAccessException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();
            var refreshTokenRepositoryMock = new Mock<IRefreshTokenRepository>();
            var loggerMock = new Mock<ILogger<LoginUserUseCase>>();

            userRepositoryMock.Setup(r => r.GetByEmailAsync("test@example.com")).ReturnsAsync((User)null);

            var useCase = new LoginUserUseCase(userRepositoryMock.Object, authServiceMock.Object, refreshTokenRepositoryMock.Object, loggerMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
                useCase.ExecuteAsync(new LoginRequestDto { Email = "test@example.com", Password = "password" }));
        }
    }
}
