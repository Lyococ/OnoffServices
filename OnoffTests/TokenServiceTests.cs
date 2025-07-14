using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onoff.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xunit;


namespace OnoffTests
{
    public class TokenServiceTests
    {
        private readonly IConfiguration _config;

        public TokenServiceTests()
        {
            var inMemorySettings = new Dictionary<string, string> {
            { "Jwt:Key", "clave_super_secreta_para_testing" },
            { "Jwt:Issuer", "TestIssuer" },
            { "Jwt:Audience", "TestAudience" }
        };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Fact]
        public void GenerateToken_ValidUser_ReturnsValidJwt()
        {
            // Arrange
            var user = new IdentityUser
            {
                Email = "test@example.com",
                Id = "user123"
            };

            var service = new JwtService(_config);

            // Act
            var token = service.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(token));

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            Assert.Equal("TestIssuer", jwt.Issuer);
            Assert.Equal("TestAudience", jwt.Audiences.First());
            Assert.Contains(jwt.Claims, c => c.Type == ClaimTypes.NameIdentifier && c.Value == "user123");
            Assert.Contains(jwt.Claims, c => c.Type == ClaimTypes.Role && c.Value == "Admin");
        }

    }
}
