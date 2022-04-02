namespace Throw.UnitTests.ValidatableExtensions.StringProperties;

[TestClass]
public class StringPropertiesLengthTests
{
    [TestMethod]
    public void ThrowIfPropertyLongerThan_WhenPropertyIsLongerThan_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLongerThan(p => p.Name, 3);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be longer than 3 characters. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyLongerThan_WhenPropertyIsNotLongerThan_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLongerThan(p => p.Name, 10);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyShorterThan_WhenPropertyIsShorterThan_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfShorterThan(p => p.Name, 10);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be shorter than 10 characters. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyShorterThan_WhenPropertyIsNotShorterThan_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfShorterThan(p => p.Name, 3);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLengthEquals_WhenPropertyLengthEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLengthEquals(p => p.Name, 7);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String length should not be equal to 7. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyLengthEquals_WhenPropertyLengthNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLengthEquals(p => p.Name, 100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyLengthNotEquals_WhenPropertyLengthNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLengthNotEquals(p => p.Name, 100);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String length should be equal to 100. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyLengthNotEquals_WhenPropertyLengthEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfLengthNotEquals(p => p.Name, 7);

        // Assert
        action.Should().NotThrow();
    }
}