namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class StringsTests
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
    public void ThrowIfLongerThan_WhenLongerThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be longer than 2 characters. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLongerThan_WhenNotLongerThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLongerThan(100);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenShorterThan_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(100);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String should not be shorter than 100 characters. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfShorterThan_WhenNotShorterThan_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfShorterThan(2);

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
            .WithMessage($"String should not be equal to 'value'. (Parameter '{nameof(value)}')");
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
            .WithMessage($"String should not be equal to 'value' (case insensitive). (Parameter '{nameof(value)}')");
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
            .WithMessage($"String should not be equal to 'VALUE' (case insensitive). (Parameter '{nameof(value)}')");
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
            .WithMessage($"String should be equal to 'different value'. (Parameter '{nameof(value)}')");
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
            .WithMessage($"String should be equal to 'different value' (case insensitive). (Parameter '{nameof(value)}')");
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

    [TestMethod]
    public void ThrowIfLenghtEquals_WhenLengthEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(value.Length);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String length should not be equal to '{value.Length}'. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLenghtEquals_WhenLengthNotEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthEquals(value.Length + 1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfLenghtNotEquals_WhenLengthNotEquals_ShouldThrow()
    {
        // Arrange
        string value = "value";
        int originalLength = value.Length;
        value = "val";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(originalLength);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"String length should be equal to '{originalLength}'. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfLenghtNotEquals_WhenLengthEquals_ShouldNotThrow()
    {
        // Arrange
        string value = "value";

        // Act
        Action action = () => value.Throw().IfLengthNotEquals(value.Length);

        // Assert
        action.Should().NotThrow();
    }
}