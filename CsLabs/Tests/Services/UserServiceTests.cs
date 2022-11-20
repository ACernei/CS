using FluentAssertions;
using NUnit.Framework;
using Services;

namespace Tests.Services;

[TestFixture]
public class UserServiceTests
{
    [Test]
    public void ValidateCreateUserShouldReturnTrue()
    {
        var database = new Dictionary<string, string>();

        var userManager = new UserManagementService(database);
        userManager.CreateUser("andrei", "admin");

        userManager.IsValid("andrei", "admin").Should().Be(true);
    }
}
