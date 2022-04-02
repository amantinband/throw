namespace Throw.UnitTests.ValidatableExtensions.StringProperties;

[TestClass]
public class StringPropertiesSubstringTests
{
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
            .WithMessage($"String should not end with 'hn' (comparison Type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyEndsWith_WhenPropertyEndsWithCustomComparisonType_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfEndsWith(p => p.Name, "HN", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not end with 'HN' (comparison Type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(person)}: p => p.Name')");
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
            .WithMessage($"String should end with 'Jo' (comparison Type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyNotEndsWith_WhenPropertyEndsWithCustomComparisonType_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotEndsWith(p => p.Name, "HN", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should().NotThrow();
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
            .WithMessage($"String should not start with 'Jo' (comparison Type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
    }

    [TestMethod]
    public void ThrowIfPropertyStartsWith_WhenPropertyStartsWithCustomComparisonType_ShouldThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfStartsWith(p => p.Name, "JO", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not start with 'JO' (comparison Type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(person)}: p => p.Name')");
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
            .WithMessage($"String should start with 'hn' (comparison Type: '{StringComparison.Ordinal}'). (Parameter '{nameof(person)}: p => p.Name')");
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
    public void ThrowIfPropertyNotStartsWith_WhenPropertyStartsWithCustomComparisonType_ShouldNotThrow()
    {
        // Arrange
        var person = new { Name = "John" };

        // Act
        Action action = () => person.Throw().IfNotStartsWith(p => p.Name, "JO", StringComparison.OrdinalIgnoreCase);

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