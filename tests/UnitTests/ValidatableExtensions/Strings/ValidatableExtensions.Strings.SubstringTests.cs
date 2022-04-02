namespace Throw.UnitTests.ValidatableExtensions.Strings;

[TestClass]
public class StringSubstringTests
{
    [TestMethod]
    public void ThrowIfEndsWith_WhenNotEndsWith_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfEndsWith("Jo");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEndsWith_WhenEndsWith_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfEndsWith("hn");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not end with 'hn' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfEndsWith_WhenEndsWithCustomComparisonType_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfEndsWith("HN", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not end with 'HN' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfNotEndsWith_WhenNotEndsWith_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotEndsWith("Jo");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should end with 'Jo' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfNotEndsWith_WhenEndsWith_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotEndsWith("hn");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEndsWith_WhenEndsWithCustomComparisonType_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotEndsWith("HN", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfStartsWith_WhenNotStartsWith_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfStartsWith("hn");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfStartsWith_WhenStartsWith_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfStartsWith("Jo");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not start with 'Jo' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfStartsWith_WhenStartsWithCustomComparisonType_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfStartsWith("JO", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not start with 'JO' (comparison type: '{StringComparison.OrdinalIgnoreCase}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfNotStartsWith_WhenNotStartsWith_ShouldThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotStartsWith("hn");

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should start with 'hn' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(name)}')");
    }

    [TestMethod]
    public void ThrowIfNotStartsWith_WhenStartsWith_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotStartsWith("Jo");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotStartsWith_WhenStartsWithCustomComparisonType_ShouldNotThrow()
    {
        // Arrange
        string name = "John";

        // Act
        Action action = () => name.Throw().IfNotStartsWith("JO", StringComparison.OrdinalIgnoreCase);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfContains_WhenContains_ShouldThrow()
    {
        // Arrange
        string value = "the quick brown fox jumps over the lazy dog.";
        string otherValue = "quick";

        // Act
        Action action = () => value.Throw().IfContains(otherValue);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not contain '{otherValue}' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfContains_WhenNotContains_ShouldNotThrow()
    {
        // Arrange
        string value = "the quick brown fox jumps over the lazy dog.";
        string otherValue = "horse";

        // Act
        Action action = () => value.Throw().IfContains(otherValue);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotContains_WhenNotContains_ShouldThrow()
    {
        // Arrange
        string value = "the quick brown fox jumps over the lazy dog.";
        string otherValue = "horse";

        // Act
        Action action = () => value.Throw().IfNotContains(otherValue);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should contain '{otherValue}' (comparison type: '{StringComparison.Ordinal}'). (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotContains_WhenContains_ShouldNotThrow()
    {
        // Arrange
        string value = "the quick brown fox jumps over the lazy dog.";
        string otherValue = "jumps";

        // Act
        Action action = () => value.Throw().IfNotContains(otherValue);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "AL", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0065\u006c", StringComparison.InvariantCulture)]
    [DataRow("\u0041\u0041", "\u0061", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfContains_WhenContainsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfContains(otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not contain '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfContains_WhenNotContainsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfContains(otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("value", "different value", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0061\u030a", "different value", StringComparison.InvariantCulture)]
    [DataRow("AA", "different value", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfNotContains_WhenNotContainsUsingCustomComparisonType_ShouldThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfNotContains(otherValue, comparisonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should contain '{otherValue}' (comparison type: '{comparisonType}'). (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("value", "AL", StringComparison.OrdinalIgnoreCase)]
    [DataRow("\u0068\u0065\u006c\u006c\u006f", "\u0065\u006c", StringComparison.InvariantCulture)]
    [DataRow("\u0041\u0041", "\u0061", StringComparison.InvariantCultureIgnoreCase)]
    public void ThrowIfNotContains_WhenContainsUsingCustomComparisonType_ShouldNotThrow(string value, string otherValue, StringComparison comparisonType)
    {
        // Act
        Action action = () => value.Throw().IfNotContains(otherValue, comparisonType);

        // Assert
        action.Should().NotThrow();
    }
}