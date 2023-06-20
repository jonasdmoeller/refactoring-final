using AutoFixture.Xunit2;
using FluentAssertions;
using LegacyApp;
using Xunit;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Theory]
    [AutoData]
    public void AddUser_WhenValidUser_ThenUserIsAdded(UserService sut)
    {
        // Act
        var actual = sut.AddUser("Linda", "Odinsdaughter", "freya@northerngods.com", new DateTime(1980, 1, 1), 1);
        
        // Assert
        actual.Should().BeTrue();
    }
}