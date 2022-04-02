using System.Text.RegularExpressions;

namespace Throw.UnitTests.ValidatableExtensions.Strings;

[TestClass]
public class StringRegexTests
{
    [DataTestMethod]
    [DataRow("Amichai", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("123456789", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My NAME", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfMatches_WhenMatchesRegexPattern_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Act
        Action action = () => value.Throw().IfMatches(regexPattern, regexOptions);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not match RegEx pattern '{regexPattern}' (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("123456789", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("Amichai", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My AGE", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfMatches_WhenMatchesRegexPattern_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Act
        Action action = () => value.Throw().IfMatches(regexPattern, regexOptions);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("Amichai", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("123456789", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My NAME", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfMatches_WhenMatchesRegex_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => value.Throw().IfMatches(regex);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not match RegEx pattern '{regexPattern}' (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("123456789", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("Amichai", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My AGE", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfMatches_WhenMatchesRegex_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => value.Throw().IfMatches(regex);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("123456789", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("Amichai", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My AGE", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfNotMatches_WhenMatchesRegexPattern_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Act
        Action action = () => value.Throw().IfNotMatches(regexPattern, regexOptions);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should match RegEx pattern '{regexPattern}' (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("Amichai", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("123456789", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My NAME", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfNotMatches_WhenMatchesRegexPattern_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Act
        Action action = () => value.Throw().IfNotMatches(regexPattern, regexOptions);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("123456789", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("Amichai", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My AGE", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfNotMatches_WhenMatchesRegex_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => value.Throw().IfNotMatches(regex);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should match RegEx pattern '{regexPattern}' (Parameter '{nameof(value)}')");
    }

    [DataTestMethod]
    [DataRow("Amichai", @"^[a-zA-Z]+$", RegexOptions.None)]
    [DataRow("123456789", @"^[0-9]+$", RegexOptions.None)]
    [DataRow("My NAME", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfNotMatches_WhenMatchesRegex_ShouldNowThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => value.Throw().IfNotMatches(regex);

        // Assert
        action.Should().NotThrow();
    }
}