namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class DateTimesTests
{
    [TestMethod]
    public void ThrowIfUtc_WhenDateTimeIsUtc_ShouldThrow()
    {
        // Arrange
        var dateTime = DateTime.UtcNow;

        // Act
        Action action = () => dateTime.Throw().IfUtc();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should not be Utc. (Parameter '{nameof(dateTime)}')");
    }

    [TestMethod]
    public void ThrowIfUtc_WhenDateTimeIsNotUtc_ShouldNotThrow()
    {
        // Arrange
        var dateTime = DateTime.Now;

        // Act
        Action action = () => dateTime.Throw().IfUtc();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotUtc_WhenDateTimeIsNotUtc_ShouldThrow()
    {
        // Arrange
        var dateTime = DateTime.Now;

        // Act
        Action action = () => dateTime.Throw().IfNotUtc();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should be Utc. (Parameter '{nameof(dateTime)}')");
    }

    [TestMethod]
    public void ThrowIfNotUtc_WhenDateTimeIsUtc_ShouldNotThrow()
    {
        // Arrange
        var dateTime = DateTime.UtcNow;

        // Act
        Action action = () => dateTime.Throw().IfNotUtc();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimeKind_WhenDateTimeKindEquals_ShouldThrow()
    {
        // Arrange
        var dateTime = DateTime.UtcNow;

        // Act
        Action action = () => dateTime.Throw().IfDateTimeKind(DateTimeKind.Utc);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should not be Utc. (Parameter '{nameof(dateTime)}')");
    }

    [TestMethod]
    public void ThrowIfDateTimeKind_WhenDateTimeKindNotEquals_ShouldNotThrow()
    {
        // Arrange
        var dateTime = DateTime.Now;

        // Act
        Action action = () => dateTime.Throw().IfDateTimeKind(DateTimeKind.Utc);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimeKindNot_WhenDateTimeKindEquals_ShouldNotThrow()
    {
        // Arrange
        var dateTime = DateTime.UtcNow;

        // Act
        Action action = () => dateTime.Throw().IfDateTimeKindNot(DateTimeKind.Utc);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimeKindNot_WhenDateTimeKindNotEquals_ShouldThrow()
    {
        // Arrange
        var dateTime = DateTime.Now;

        // Act
        Action action = () => dateTime.Throw().IfDateTimeKindNot(DateTimeKind.Utc);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value should be Utc. (Parameter '{nameof(dateTime)}')");
    }
}