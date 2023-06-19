using FluentAssertions;
using LegacyApp;
using Xunit;

namespace LegacyAppTests;

public class ClientRepositoryTests
{
    [Fact]
    public void GetById_WhenClientExists_ReturnsClient()
    {
        // Arrange
        var sut = new ClientRepository();
        
        // Act
        var actual = sut.GetById(1);

        // Assert
        actual.Name.Should().Be("Zeus");
    }
    
    [Fact]
    public void GetById_WhenClientDoesNotExists_ThenThrowException()
    {
        // Arrange
        var sut = new ClientRepository();
        
        // Act
        var action = () => sut.GetById(-1);
        
        // Assert
        action.Should().Throw<Exception>().WithMessage("Client not found");
    }
}
