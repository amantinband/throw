namespace Throw.UnitTests.ValidatableExtensions.Strings;

[TestClass]
public class StringLengthTests
{
    [TestMethod]
    public void ThrowIfLongerThan_WhenLongerThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be longer than 2 characters. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLongerThan_WhenNotLongerThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenShorterThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(100);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be shorter than 100 characters. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenNotShorterThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfLengthEquals_WhenLengthEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String length should not be equal to 5. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLengthEquals_WhenLengthNotEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfLengthNotEquals_WhenLengthNotEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(100);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String length should be equal to 100. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLengthNotEquals_WhenLengthEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(value.Length);

        // Assert
        action.Should().NotThrow();
    }
}