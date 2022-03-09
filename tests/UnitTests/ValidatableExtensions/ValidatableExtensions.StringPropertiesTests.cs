namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class StringPropertiesTests
{
    [TestMethod]
    public void ThrowIfPropertyWhiteSpace_WhenPropertyIsWhiteSpace_ShouldThrow()
    {
        // Arrange
        var person = new { Name = " " };

        // Act
        Action action = () => person.Throw().IfWhiteSpace(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be white space only. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyWhiteSpace_WhenPropertyIsNotWhiteSpace_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfWhiteSpace(p => p.Name);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrEmpty_WhenPropertyIsNull_ShouldThrow()
    {
        // Arrange
        var person = new { Name = null as string };

        // Act
        Action action = () => person.Throw().IfNullOrEmpty(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be null or empty. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrEmpty_WhenPropertyIsEmpty_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "" };

        // Act
        Action action = () => person.Throw().IfNullOrEmpty(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be null or empty. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrEmpty_WhenPropertyIsWhiteSpace_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = " " };

        // Act
        Action action = () => person.Throw().IfNullOrEmpty(p => p.Name);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrEmpty_WhenPropertyNotEmpty_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Milan" };

        // Act
        Action action = () => person.Throw().IfNullOrEmpty(p => p.Name);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrWhiteSpace_WhenPropertyIsNull_ShouldThrow()
    {
        // Arrange
        var person = new { Name = null as string };

        // Act
        Action action = () => person.Throw().IfNullOrWhiteSpace(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be null or whitespace. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrWhiteSpace_WhenPropertyIsEmpty_ShouldThrow()
    {
        // Arrange
        var person = new { Name = " " };

        // Act
        Action action = () => person.Throw().IfNullOrWhiteSpace(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be null or whitespace. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrWhiteSpace_WhenPropertyIsWhiteSpace_ShouldThrow()
    {
        // Arrange
        var person = new { Name = " " };

        // Act
        Action action = () => person.Throw().IfNullOrWhiteSpace(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be null or whitespace. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNullOrWhiteSpace_WhenPropertyIsNotWhiteSpace_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Milan" };

        // Act
        Action action = () => person.Throw().IfNullOrWhiteSpace(p => p.Name);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyEmpty_WhenPropertyIsEmpty_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "" };

        // Act
        Action action = () => person.Throw().IfEmpty(p => p.Name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be empty. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyEmpty_WhenPropertyNotEmpty_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEmpty(p => p.Name);

        // Assert
        action.Should().NotThrow();
    }

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
    public void ThrowIfPropertyEquals_WhenPropertyEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEquals(p => p.Name, "Amichai");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'Amichai'. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyEquals_WhenPropertyNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEquals(p => p.Name, "Amichai2");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNotEquals_WhenPropertyNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfNotEquals(p => p.Name, "Amiko");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to 'Amiko'. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEquals_WhenPropertyEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfNotEquals(p => p.Name, "Amichai");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyEqualsIgnoreCase_WhenPropertyEqualsSameCase_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEqualsIgnoreCase(p => p.Name, "Amichai");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'Amichai' (case insensitive). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyEqualsIgnoreCase_WhenPropertyEqualsDifferentCase_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEqualsIgnoreCase(p => p.Name, "AMICHAI");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'Amichai' (case insensitive). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyEqualsIgnoreCase_WhenPropertyNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEqualsIgnoreCase(p => p.Name, "Amiko");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNotEqualsIgnoreCase_WhenPropertyNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfNotEqualsIgnoreCase(p => p.Name, "Amiko");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to 'Amiko' (case insensitive). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEqualsIgnoreCase_WhenPropertyEqualsSameCase_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfNotEqualsIgnoreCase(p => p.Name, "Amichai");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNotEqualsIgnoreCase_WhenPropertyEqualsDifferentCase_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfNotEqualsIgnoreCase(p => p.Name, "AMICHAI");

        // Assert
        action.Should().NotThrow();
    }
}