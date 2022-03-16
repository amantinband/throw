namespace Throw.UnitTests.ValidatableExtensions.StringProperties;

[TestClass]
public class StringPropertiesEqualityTests
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
        var person = new { Name = "" };

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
    public void ThrowIfPropertyEquals_WhenPropertyEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "Amichai" };

        // Act
        Action action = () => person.Throw().IfEquals(p => p.Name, "Amichai");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'Amichai' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
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

    [DataTestMethod]
    [DataRow("value", "VALUE", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "\u00e5", StringComparison.InvariantCulture)]
    [DataRow("AA", "A\u0000\u0000\u0000a", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyEquals_WhenPropertyEqualsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfEquals(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyEquals_WhenPropertyNotEqualsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfEquals(p => p.Name, otherValue, comparisonType);

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
            .WithMessage($"String should be equal to 'Amiko' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
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

    [DataTestMethod]
    [DataRow("value", "VALUE", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "\u00e5", StringComparison.InvariantCulture)]
    [DataRow("AA", "A\u0000\u0000\u0000a", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyNotEquals_WhenPropertyEqualsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotEquals(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyNotEquals_WhenPropertyNotEqualsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotEquals(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(person)}: p => p.Name')");
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
            .WithMessage($"String should not be equal to 'Amichai' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(person)}: p => p.Name')");
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
            .WithMessage($"String should not be equal to 'Amichai' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(person)}: p => p.Name')");
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
            .WithMessage($"String should be equal to 'Amiko' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(person)}: p => p.Name')");
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