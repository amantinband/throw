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

    [TestMethod]
    public void ThrowIfPropertyEndsWith_WhenPropertyNotEndsWith_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfEndsWith(p => p.Name, "Jo");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyEndsWith_WhenPropertyEndsWith_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfEndsWith(p => p.Name, "hn");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not end with 'hn'. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEndsWith_WhenPropertyNotEndsWith_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotEndsWith(p => p.Name, "Jo");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should end with 'Jo'. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEndsWith_WhenPropertyEndsWith_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotEndsWith(p => p.Name, "hn");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyStartsWith_WhenPropertyNotStartsWith_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfStartsWith(p => p.Name, "hh");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyStartsWith_WhenPropertyStartsWith_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfStartsWith(p => p.Name, "Jo");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not start with 'Jo'. (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotStartsWith_WhenPropertyNotStartsWith_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotStartsWith(p => p.Name, "hn");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should start with 'hn'. (Parameter '{nameof(person)}: p => p.Name')");

    }

    [TestMethod]
    public void ThrowIfPropertyNotStartsWith_WhenPropertyStartsWith_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotStartsWith(p => p.Name, "Jo");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyContains_WhenPropertyContains_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Name, "oh");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should not contain 'oh' (comparison Type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyContains_WhenPropertyNotContains_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Name, "Oh");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPropertyNotContains_WhenPropertyNotContains_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Name, "Oh");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"String should contain 'Oh' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotContains_WhenPropertyContains_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Name, "oh");

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "AL", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0065", StringComparison.InvariantCulture)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0045", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyContains_WhenPropertyContainsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not contain '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("value", "123", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0041\u0041", "\u0031", StringComparison.InvariantCulture)]
    [DataRow("AA", "\u0031", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyContains_WhenPropertyNotContainsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }
    
    [DataTestMethod]
    [DataRow("value", "123", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0041\u0041", "\u0031", StringComparison.InvariantCulture)]
    [DataRow("AA", "\u0031", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyNotContains_WhenPropertyNotContainsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should contain '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("value", "AL", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0065", StringComparison.InvariantCulture)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0045", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfPropertyNotContains_WhenPropertyContainsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Name, otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }
}