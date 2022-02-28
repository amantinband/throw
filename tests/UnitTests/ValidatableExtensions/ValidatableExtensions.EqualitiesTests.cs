namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class EqualitiesTests
{
    [TestMethod]
    public void ThrowIfDefault_WhenValueIsDefault_ShouldThrow()
    {
        // Arrange
        DateTime value = default;

        // Act
        Action action = () => value.Throw().IfDefault();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be default. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfDefault_WhenValueIsNotDefault_ShouldNotThrow()
    {
        // Arrange
        DateTime value = DateTime.Now;

        // Act
        Action action = () => value.Throw().IfDefault();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotDefault_WhenValueIsNotDefault_ShouldThrow()
    {
        // Arrange
        DateTime value = DateTime.Now;

        // Act
        Action action = () => value.Throw().IfNotDefault();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be default. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotDefault_WhenValueIsDefault_ShouldNotThrow()
    {
        // Arrange
        DateTime value = default;

        // Act
        Action action = () => value.Throw().IfNotDefault();

        // Assert
        action.Should().NotThrow();
    }
}