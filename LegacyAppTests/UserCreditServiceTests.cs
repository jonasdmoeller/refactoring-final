using FluentAssertions;
using LegacyApp;
using Xunit;

namespace LegacyAppTests;

public class UserCreditServiceTests
{
    [Fact]
    public void GetCreditLimit_WhenNameDoesNotContainsF_ThenReturnNumberGreaterThanZero()
    {
        // Arrange
        var sut = new UserCreditService();
        
        // Act
        var actual = sut.GetCreditLimit("Sam", "Gamgee", new DateTime(1960, 1, 1));

        // Assert
        actual.Should().BeGreaterThan(0);
    }

    [Fact]
    public void GetCreditLimit_WhenNameContainsF_ThenReturnZero()
    {
        // Arrange
        var sut = new UserCreditService();
        
        // Act
        var actual = sut.GetCreditLimit("Frodo", "Baggins", new DateTime(1960, 1, 1));

        // Assert
        actual.Should().Be(0);
    }
}
