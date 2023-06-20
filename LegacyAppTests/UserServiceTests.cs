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

    [Fact]
    public void AddUser_InvalidFirstname_ThenUserIsNotAdded()
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("", "Odinsdaughter", "foo@bar.dk", new DateTime(1980, 1, 1), 1);
        
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void AddUser_InvalidSurname_ThenUserIsNotAdded()
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("Linda", "", "ai@sucks.com", new DateTime(1980, 1, 1), 1);
        Assert.False(actual);
    }
    
    [Theory]
    [InlineData("foo@bar")]
    public void AddUser_InvalidEmail_ThenUserIsNotAdded(string email)
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("Linda", "Odinsdaughter", email, new DateTime(1980, 1, 1), 1);
        
        // Assert
        actual.Should().BeFalse($"because the email: '{email}' is invalid");
    }

    [Theory]
    [InlineData("foo@bar.com")]
    [InlineData("foo@bar.")]
    [InlineData("")]
    [InlineData("foo")]
    [InlineData("foobar.com")]
    public void AddUser_ValidEmail_ThenUserIsAdded(string email)
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("Linda", "Odinsdaughter", email, new DateTime(1980, 1, 1), 1);
        
        // Assert
        actual.Should().BeTrue($"because the email: '{email}' is valid");
    }

    [Fact]
    public void AddUser_InvalidAge_ThenUserIsNotAdded()
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("Linda", "Odinsdaughter", "foo@bar.dk", new DateTime(2020, 1, 1), 1);

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void AddUser_WhenValidUserAndVeryImportantClient_ThenUserIsAdded()
    {
        // Arrange
        var sut = new UserService();

        // Act
        var actual = sut.AddUser("Linda", "Odinsdaughter", "foo@bar.xo", new DateTime(1980, 1, 1), 2);

        // Assert
        Assert.True(actual);
    }
}