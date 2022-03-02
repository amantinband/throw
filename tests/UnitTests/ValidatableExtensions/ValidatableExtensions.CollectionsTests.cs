namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class CollectionsTests
{
    [TestMethod]
    public void ThrowIfCollectionEmpty_WhenCollectionIsEmpty_ShouldThrow()
    {
        // Arrange
        var collection = Array.Empty<int>();

        // Act
        Action action = () => collection.Throw().IfEmpty();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection should not be empty. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionEmpty_WhenCollectionIsNotEmpty_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfEmpty();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionNotEmpty_WhenCollectionIsNotEmpty_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfNotEmpty();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection should be empty. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionNotEmpty_WhenCollectionIsEmpty_ShouldNotThrow()
    {
        // Arrange
        var collection = Array.Empty<string>();

        // Act
        Action action = () => collection.Throw().IfNotEmpty();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountEquals_WhenCollectionCountEquals_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountEquals(1);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection count should not be equal to 1. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionCountEquals_WhenCollectionCountNotEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountEquals(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountNotEquals_WhenCollectionCountNotEquals_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountNotEquals(2);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection count should be equal to 2. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionCountNotEquals_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountNotEquals(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountGreaterThan_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(0);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection count should not be greater than 0. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountNotGreaterThan_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountGreaterThan_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountGreaterThan(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountLessThan_ShouldThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(2);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection count should not be less than 2. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountNotLessThan_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(0);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionCountLessThan_WhenCollectionCountEquals_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        Action action = () => collection.Throw().IfCountLessThan(1);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfCollectionHasNullElements_WhenCollectionHasNullElements_ShouldThrow()
    {
        // Arrange
        var collection = new[] { "hey", null };

        // Act
        Action action = () => collection.Throw().IfHasNullElements();

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Collection should not have null elements. (Parameter '{nameof(collection)}')");
    }

    [TestMethod]
    public void ThrowIfCollectionHasNullElements_WhenCollectionHasNoNullElements_ShouldNotThrow()
    {
        // Arrange
        var collection = new[] { "hey", "ho" };

        // Act
        Action action = () => collection.Throw().IfHasNullElements();

        // Assert
        action.Should().NotThrow();
    }
}