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
        var userManager = new UserManagementService();
        userManager.CreateUser("andrei", "admin");

        userManager.IsValid("andrei", "admin").Should().Be(true);
    }
}
