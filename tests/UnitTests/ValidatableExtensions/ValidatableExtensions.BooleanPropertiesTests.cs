namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class BooleanPropertiesTests
{
    [TestMethod]
    public void ThrowIfPropertyTrue_WhenPropertyIsTrue_ShouldThrow()
    {
        // Arrange
        var person = new { Id = 1 };

        // Act
        Action action = () => person.Throw().IfTrue(p => p.Id == 1);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not meet condition (condition: 'p => p.Id == 1'). (Parameter '{nameof(person)}')");
    }

    [TestMethod]
    public void ThrowIfPropertyTrue_WhenPropertyIsFalse_ShouldNotThrow()
    {
        // Arrange
        var person = new { Id = 1 };

        // Act
        Action action = () => person.Throw().IfTrue(p => p.Id == 2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyFalse_WhenPropertyIsFalse_ShouldThrow()
    {
        // Arrange
        var person = new { Id = 1 };

        // Act
        Action action = () => person.Throw().IfFalse(p => p.Id == 2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should meet condition (condition: 'p => p.Id == 2'). (Parameter '{nameof(person)}')");
    }

    [TestMethod]
    public void ThrowIfPropertyFalse_WhenPropertyIsTrue_ShouldNotThrow()
    {
        // Arrange
        var person = new { Id = 1 };

        // Act
        Action action = () => person.Throw().IfFalse(p => p.Id == 1);

        // Assert
        action.Should().NotThrow();
    }
}