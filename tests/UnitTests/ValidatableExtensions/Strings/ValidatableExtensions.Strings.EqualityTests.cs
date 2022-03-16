namespace Throw.UnitTests.ValidatableExtensions.Strings;

[TestClass]
public class StringEqualityTests
{
    [TestMethod]
    public void ThrowIfWhiteSpace_WhenWhiteSpace_ShouldThrow()
    {
        // Arrange
        string value = " ";

        // Act
        Action action = () => value.Throw().IfWhiteSpace();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be white space only. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfWhiteSpace_WhenNotWhiteSpace_ShouldNotThrow()
    {
        // Arrange
        string value = "not white space";

        // Act
        Action action = () => value.Throw().IfWhiteSpace();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEmpty_WhenEmpty_ShouldThrow()
    {
        // Arrange
        string value = "";

        // Act
        Action action = () => value.Throw().IfEmpty();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be empty. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfEmpty_WhenNotEmpty_ShouldNotThrow()
    {
        // Arrange
        string value = "not empty";

        // Act
        Action action = () => value.Throw().IfEmpty();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEquals_WhenEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfEquals("value");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'value' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfEquals_WhenNotEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfEquals("VALUE");

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "VALUE", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "\u00e5", StringComparison.InvariantCulture)]
    [DataRow("AA", "A\u0000\u0000\u0000a", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfEquals_WhenEqualsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfEquals(otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfEquals_WhenNotEqualsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfEquals(otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEqualsIgnoreCase_WhenEqualsSameCase_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfEqualsIgnoreCase("value");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'value' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfEqualsIgnoreCase_WhenEqualsDifferentCase_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfEqualsIgnoreCase("VALUE");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be equal to 'VALUE' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfEqualsIgnoreCase_WhenNotEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfEqualsIgnoreCase("different value");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenNotEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfNotEquals("different value");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to 'different value' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("value", "VALUE", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "\u00e5", StringComparison.InvariantCulture)]
    [DataRow("AA", "A\u0000\u0000\u0000a", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfNotEquals_WhenEqualsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfNotEquals(otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfNotEquals_WhenNotEqualsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfNotEquals(otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfNotEquals("value");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEqualsIgnoreCase_WhenNotEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfNotEqualsIgnoreCase("different value");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should be equal to 'different value' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotEqualsIgnoreCase_WhenEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfNotEqualsIgnoreCase("value");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEqualsIgnoreCase_WhenEqualsDifferentCase_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfNotEqualsIgnoreCase("VALUE");

        // Assert
        action.Should().NotThrow();
    }
}