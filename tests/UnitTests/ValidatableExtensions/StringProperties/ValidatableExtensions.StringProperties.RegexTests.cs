using System.Text.RegularExpressions;

namespace Throw.UnitTests.ValidatableExtensions.StringProperties;

[TestClass]
public class StringPropertiesRegexTests
{
    [DataTestMethod]
    [DataRow("Amichai", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Haman", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("My Name", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyMatches_WhenPropertyMatchesRegexPattern_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfMatches(p => p.Name, regexPattern, regexOptions);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not match RegEx pattern '{regexPattern}' (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("123456789", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Amichai", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("No Match", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyMatches_WhenPropertyNotMatchesRegexPattern_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfMatches(p => p.Name, regexPattern, regexOptions);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("Amichai", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Haman", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("My Name", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyMatches_WhenPropertyMatchesRegex_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => person.Throw().IfMatches(p => p.Name, regex);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not match RegEx pattern '{regex}' (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("123456789", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Amichai", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("No Match", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyMatches_WhenPropertyNotMatchesRegex_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => person.Throw().IfMatches(p => p.Name, regex);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("123456789", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Amichai", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("No Match", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyNotMatches_WhenPropertyNotMatchesRegexPattern_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotMatches(p => p.Name, regexPattern, regexOptions);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should match RegEx pattern '{regexPattern}' (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("Amichai", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Haman", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("My Name", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyNotMatches_WhenPropertyMatchesRegexPattern_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };

        // Act
        Action action = () => person.Throw().IfNotMatches(p => p.Name, regexPattern, regexOptions);

        // Assert
        action.Should().NotThrow();
    }

    [DataTestMethod]
    [DataRow("123456789", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Amichai", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("No Match", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyNotMatches_WhenPropertyNotMatchesRegex_ShouldThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => person.Throw().IfNotMatches(p => p.Name, regex);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should match RegEx pattern '{regex}' (Parameter '{nameof(person)}: p => p.Name')");
    }

    [DataTestMethod]
    [DataRow("Amichai", @"[a-zA-Z]", RegexOptions.None)]
    [DataRow("Haman", @"\b[H]\w+", RegexOptions.None)]
    [DataRow("My Name", @"\bname\b", RegexOptions.IgnoreCase)]
    public void ThrowIfPropertyNotMatches_WhenPropertyMatchesRegex_ShouldNotThrow(string value, string regexPattern, RegexOptions regexOptions)
    {
        // Arrange
        var person = new { Name = value };
        var regex = new Regex(regexPattern, regexOptions);

        // Act
        Action action = () => person.Throw().IfNotMatches(p => p.Name, regex);

        // Assert
        action.Should().NotThrow();
    }
}