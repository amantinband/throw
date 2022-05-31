namespace Throw.UnitTests.ValidatableMethods;

[TestClass]
public class TypesTests
{
    [TestMethod]
    public void ThrowIfType_WhenValueIsType_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfType<string>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Parameter should not be of type '{str.GetType().Name}'. (Parameter '{nameof(str)}')");
    }

    [TestMethod]
    public void ThrowIfType_WhenCompileTypesNotEqualButRuntimeEquals_ShouldNotThrow()
    {
        // Arrange
        IList<int> list = new List<int>();

        // Act
        Action action = () => list.Throw().IfType<List<int>>();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfType_WhenValueIsNotType_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action2 = () => list.Throw().IfType<int>();

        // Assert
        action2.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotType_WhenValueIsNotType_ShouldThrow()
    {
        // Arrange
        string str = "string";

        // Act
        Action action = () => str.Throw().IfNotType<int>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Parameter should be of type '{typeof(int).Name}'. (Parameter '{nameof(str)}')");
    }

    [TestMethod]
    public void ThrowIfNotType_WhenValueIsType_ShouldNotThrow()
    {
        // Arrange
        List<int> list = new();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotType_WhenCompileTypesNotEqualButRuntimeEquals_ShouldThrow()
    {
        // Arrange
        IList<int> list = new List<int>();

        // Act
        Action action = () => list.Throw().IfNotType<List<int>>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Parameter should be of type '{typeof(List<int>).Name}'. (Parameter '{nameof(list)}')");
    }
}
