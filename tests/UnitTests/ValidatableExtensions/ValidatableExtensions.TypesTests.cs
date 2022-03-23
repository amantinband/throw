using System.Collections.Generic;

namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class TypesTests
{
    [TestMethod]
    public void ThrowIfType_WhenValueIsType_ShouldThrow()
    {
        // Arrange
        string str = "string";
        List<int> list = new List<int>(0);


        // Act
        Action action = () => str.Throw().IfType<string>();
        Action action2 = () => list.Throw().IfType<List<int>>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Type shouldn't be {typeof(string)} (Parameter '{nameof(str)}')");

        action2.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Type shouldn't be {typeof(List<int>)} (Parameter '{nameof(list)}')");
    }

    [TestMethod]
    public void ThrowIfType_WhenValueIsNotType_ShouldNotThrow()
    {
        // Arrange
        string str = "string";
        List<int> list = new List<int>(0);


        // Act
        Action action = () => str.Throw().IfType<int>();
        Action action2 = () => list.Throw().IfType<int>();

        // Assert
        action.Should().NotThrow();
        action2.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotType_WhenValueIsNotType_ShouldThrow()
    {
        // Arrange
        string str = "string";
        List<int> list = new List<int>(0);


        // Act
        Action action = () => str.Throw().IfNotType<int>();
        Action action2 = () => list.Throw().IfNotType<int>();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Type should be {typeof(int)} (Parameter '{nameof(str)}')");

        action2.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Type should be {typeof(int)} (Parameter '{nameof(list)}')");
    }

    [TestMethod]
    public void ThrowIfNotType_WhenValueIsType_ShouldNotThrow()
    {
        // Arrange
        string str = "string";
        List<int> list = new List<int>(0);


        // Act
        Action action = () => str.Throw().IfNotType<string>();
        Action action2 = () => list.Throw().IfNotType<List<int>>();

        // Assert
        action.Should().NotThrow();
        action2.Should().NotThrow();
    }
}