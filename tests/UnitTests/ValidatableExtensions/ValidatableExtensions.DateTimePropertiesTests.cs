namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class DateTimePropertiesTests
{
    [TestMethod]
    public void ThrowIfDateTimePropertyUtc_WhenValueIsUtc_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.UtcNow };

        // Act
        Action action = () => person.Throw().IfUtc(p => p.BirthDate);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be Utc. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfDateTimePropertyUtc_WhenValueIsNotUtc_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfUtc(p => p.BirthDate);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimePropertyNotUtc_WhenValueIsNotUtc_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfNotUtc(p => p.BirthDate);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be Utc. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfDateTimePropertyNotUtc_WhenValueIsUtc_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.UtcNow };

        // Act
        Action action = () => person.Throw().IfNotUtc(p => p.BirthDate);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimeKindPropertyUtc_WhenValueIsUtc_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.UtcNow };

        // Act
        Action action = () => person.Throw().IfDateTimeKind(p => p.BirthDate, DateTimeKind.Utc);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be Utc. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfDateTimeKindPropertyUtc_WhenValueIsNotUtc_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfDateTimeKind(p => p.BirthDate, DateTimeKind.Utc);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfDateTimeKindPropertyNotUtc_WhenValueIsNotUtc_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfDateTimeKindNot(p => p.BirthDate, DateTimeKind.Utc);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be Utc. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfDateTimeKindPropertyNotUtc_WhenValueIsUtc_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.UtcNow };

        // Act
        Action action = () => person.Throw().IfDateTimeKindNot(p => p.BirthDate, DateTimeKind.Utc);

        // Assert
        action.Should().NotThrow();
    }
}
