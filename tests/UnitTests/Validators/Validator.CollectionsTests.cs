namespace Throw.UnitTests.Validators;

[TestClass]
public class CollectionsValidatorTests
{
    [TestMethod]
    public void GetCollectionCount_WhenCollectionIsArray_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new[] { 1 };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        count.Should().Be(collection.Length);
    }

    [TestMethod]
    public void GetCollectionCount_WhenCollectionIsList_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new List<int> { 1 };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        count.Should().Be(collection.Count);
    }

    [TestMethod]
    public void GetCollectionCount_WhenCollectionIsDictionary_ShouldReturnCollectionCount()
    {
        // Arrange
        var collection = new Dictionary<int, int> { { 1, 1 } };

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        count.Should().Be(collection.Count);
    }

    [TestMethod]
    public void GetCollectionCount_WhenCollectionIsIEnumerable_ShouldReturnEnumeratedCount()
    {
        // Arrange
        var numItems = 10;
        var collection = Enumerable.Range(0, numItems);

        // Act
        var count = Validator.GetCollectionCount(collection);

        // Assert
        count.Should().Be(numItems);
    }

    [TestMethod]
    public void GetCollectionCount_WhenCollectionIsString_ShouldReturnStringLength()
    {
        // Arrange
        var str = "hello";

        // Act
        var count = Validator.GetCollectionCount(str);

        // Assert
        count.Should().Be(str.Length);
    }
}
