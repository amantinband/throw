namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class ComperablePropertiesTests
{
    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyGreaterThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 4);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should not be greater than 4. (Parameter '{nameof(value)}: v => v.Property')\nActual value was {value.Property}.");
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyGreaterThan_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfGreaterThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyLessThan_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should not be less than 6. (Parameter '{nameof(value)}: v => v.Property')\nActual value was {value.Property}.");
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLessThan_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfLessThan(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyEquals_WhenPropertyEquals_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfEquals(v => v.Property, 5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be equal to 5. (Parameter '{nameof(value)}: v => v.Property')");
    }

    [TestMethod]
    public void ThrowIfPropertyEquals_WhenPropertyNotEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfEquals(v => v.Property, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNotEquals_WhenPropertyNotEquals_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfNotEquals(v => v.Property, 6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be equal to 6. (Parameter '{nameof(value)}: v => v.Property')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEquals_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfNotEquals(v => v.Property, 5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyPositive_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should not be greater than 0. (Parameter '{nameof(value)}: v => v.Property')\nActual value was {value.Property}.");
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyNegative_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyPositive_WhenPropertyZero_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfPositive(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyNegative_ShouldThrow()
    {
        // Arrange
        var value = new { Property = -5 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should not be less than 0. (Parameter '{nameof(value)}: v => v.Property')\nActual value was {value.Property}.");
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyPositive_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNegative_WhenPropertyZero_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 0 };

        // Act
        Action action = () => value.Throw().IfNegative(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyOutOfRange_ShouldThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 0, 4);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should be between 0 and 4. (Parameter '{nameof(value)}: v => v.Property')\nActual value was {value.Property}.");
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyInRange_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 4, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyEqualsLowerBound_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 5, 6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyOutOfRange_WhenPropertyEqualsUpperBound_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = 5 };

        // Act
        Action action = () => value.Throw().IfOutOfRange(v => v.Property, 4, 5);

        // Assert
        action.Should().NotThrow();
    }
}