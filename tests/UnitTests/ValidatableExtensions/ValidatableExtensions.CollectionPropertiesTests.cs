namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class CollectionPropertiesTests
{
    [TestMethod]
    public void ThrowIfCollectionPropertyIsEmpty_WhenCollectionPropertyIsEmpty_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = Array.Empty<string>() };

        // Act
        Action action = () => person.Throw().IfEmpty(p => p.Friends);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection should not be empty. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyIsEmpty_WhenCollectionPropertyIsNotEmpty_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfEmpty(p => p.Friends);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyIsNotEmpty_WhenCollectionPropertyIsNotEmpty_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's dad" } };

        // Act
        Action action = () => person.Throw().IfNotEmpty(p => p.Friends);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection should be empty. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyIsNotEmpty_WhenCollectionPropertyIsEmpty_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = Array.Empty<string>() };

        // Act
        Action action = () => person.Throw().IfNotEmpty(p => p.Friends);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountEquals_WhenCollectionPropertyCountEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountEquals(p => p.Friends, 1);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection count should not be equal to 1. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountEquals_WhenCollectionPropertyCountNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountEquals(p => p.Friends, 2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountNotEquals_WhenCollectionPropertyCountNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountNotEquals(p => p.Friends, 2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection count should be equal to 2. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountNotEquals_WhenCollectionPropertyCountEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountNotEquals(p => p.Friends, 1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountGreaterThan_WhenCollectionPropertyCountGreaterThan_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountGreaterThan(p => p.Friends, 0);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage(
                $"Collection count should not be greater than 0. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountGreaterThan_WhenCollectionPropertyCountNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountGreaterThan(p => p.Friends, 2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountGreaterThan_WhenCollectionPropertyCountEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountGreaterThan(p => p.Friends, 1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountLessThan_WhenCollectionPropertyCountLessThan_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountLessThan(p => p.Friends, 2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection count should not be less than 2. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountLessThan_WhenCollectionPropertyCountNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountLessThan(p => p.Friends, 0);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyCountLessThan_WhenCollectionPropertyCountEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfCountLessThan(p => p.Friends, 1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyHasNullElements_WhenCollectionPropertyHasNullElements_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom", null } };

        // Act
        Action action = () => person.Throw().IfHasNullElements(p => p.Friends);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Collection should not have null elements. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyHasNullElements_WhenCollectionPropertyHasNoNullElements_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfHasNullElements(p => p.Friends);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyContainsElement_WhenCollectionPropertyContainsElement_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Friends, "Amichai's mom");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Collection should not contain element. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyContainsElement_WhenCollectionPropertyNotContainsElement_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { null, "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfContains(p => p.Friends, "Amichai's dad");

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyNotContainsElement_WhenCollectionPropertyNotContainsElement_ShouldThrow()
    {
        // Arrange
        var person = new { Friends = new[] { null, "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Friends, "Amichai's dad");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Collection should contain element. (Parameter '{nameof(person)}: p => p.Friends')");
    }

    [TestMethod]
    public void ThrowIfCollectionPropertyNotContainsElement_WhenCollectionPropertyContainsElement_ShouldNotThrow()
    {
        // Arrange
        var person = new { Friends = new[] { null, "Amichai's mom" } };

        // Act
        Action action = () => person.Throw().IfNotContains(p => p.Friends, "Amichai's mom");

        // Assert
        action.Should().NotThrow();
    }
}
