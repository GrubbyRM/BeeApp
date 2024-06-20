using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;
using BeeApp.Aplication.ApplicationUser;
using System;
using Assert = Xunit.Assert; // Alias dla Xunit.Assert

namespace BeeApp.Tests
{
    public class UserContextTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly UserContext _userContext;

        public UserContextTests()
        {
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _userContext = new UserContext(_httpContextAccessorMock.Object);
        }

        [Fact]
        public void GetCurrentUser_ShouldReturnCurrentUser_WhenUserIsAuthenticated()
        {
            // Arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "123"),
                new Claim(ClaimTypes.Email, "test@example.com")
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var principal = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext { User = principal };

            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);

            // Act
            var result = _userContext.GetCurrentUser();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("123", result.Id);
            Assert.Equal("test@example.com", result.Email);
        }
    }
}
