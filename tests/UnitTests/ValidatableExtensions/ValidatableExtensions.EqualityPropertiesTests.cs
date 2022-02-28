namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class EqualityPropertiesTests
{
    [TestMethod]
    public void ThrowIfPropertyIsNull_WhenPropertyIsNull_ShouldThrow()
    {
        // Arrange
        var value = new { Property = null as string };

        // Act
        Action action = () => value.Throw().IfNull(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage($"Value cannot be null. (Parameter '{nameof(value)}: v => v.Property')");
    }

    [TestMethod]
    public void ThrowIfPropertyIsNull_WhenPropertyIsNotNull_ShouldNotThrow()
    {
        // Arrange
        var value = new { Property = "value" };

        // Act
        Action action = () => value.Throw().IfNull(v => v.Property);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyIsNotNull_WhenPropertyIsNotNull_ShouldThrow()
    {
        // Arrange
        var value = new { Property = "value" };

        // Act
        Action action = () => value.Throw().IfNotNull(v => v.Property);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be null. (Parameter '{nameof(value)}: v => v.Property')");
    }

    [TestMethod]
    public void ThrowIfPropertyIsDefault_WhenValueIsDefault_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = default(DateTime) };

        // Act
        Action action = () => person.Throw().IfDefault(p => p.BirthDate);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be default. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfPropertyIsDefault_WhenValueIsNotDefault_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfDefault(p => p.BirthDate);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyIsNotDefault_WhenValueIsNotDefault_ShouldThrow()
    {
        // Arrange
        var person = new { BirthDate = DateTime.Now };

        // Act
        Action action = () => person.Throw().IfNotDefault(p => p.BirthDate);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be default. (Parameter '{nameof(person)}: p => p.BirthDate')");
    }

    [TestMethod]
    public void ThrowIfPropertyIsNotDefault_WhenValueIsDefault_ShouldNotThrow()
    {
        // Arrange
        var person = new { BirthDate = default(DateTime) };

        // Act
        Action action = () => person.Throw().IfNotDefault(p => p.BirthDate);

        // Assert
        action.Should().NotThrow();
    }
}