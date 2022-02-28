namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class BooleansTests
{
    [TestMethod]
    public void ThrowIfTrue_WhenValueIsTrue_ShouldThrow()
    {
        // Arrange
        bool value = true;

        // Act
        Action action = () => value.Throw().IfTrue();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should not be true. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfTrue_WhenValueIsFalse_ShouldNotThrow()
    {
        // Arrange
        bool value = false;

        // Act
        Action action = () => value.Throw().IfTrue();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfFalse_WhenValueIsTrue_ShouldNotThrow()
    {
        // Arrange
        bool value = true;

        // Act
        Action action = () => value.Throw().IfFalse();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfFalse_WhenValueIsFalse_ShouldThrow()
    {
        // Arrange
        bool value = false;

        // Act
        Action action = () => value.Throw().IfFalse();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should be true. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfConditionTrue_WhenConditionIsTrue_ShouldThrow()
    {
        // Arrange
        var value = "value";

        // Act
        Action action = () => value.Throw().IfTrue(value.Length > 0);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not meet condition (condition: 'value.Length > 0'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfConditionTrue_WhenConditionIsFalse_ShouldNotThrow()
    {
        // Arrange
        var value = "value";

        // Act
        Action action = () => value.Throw().IfTrue(value.Length == 0);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfConditionFalse_WhenConditionIsTrue_ShouldNotThrow()
    {
        // Arrange
        var value = "value";

        // Act
        Action action = () => value.Throw().IfFalse(value.Length > 0);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfConditionFalse_WhenConditionIsFalse_ShouldThrow()
    {
        // Arrange
        var value = "value";

        // Act
        Action action = () => value.Throw().IfFalse(value.Length == 0);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should meet condition (condition: 'value.Length == 0'). (Parameter '{nameof(value)}')");
    }
}