namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class EqualitiesTests
{
    [TestMethod]
    public void ThrowIfDefault_WhenValueIsDefault_ShouldThrow()
    {
        // Arrange
        DateTime value = default;

        // Act
        Action action = () => value.Throw().IfDefault();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be default. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfDefault_WhenValueIsNotDefault_ShouldNotThrow()
    {
        // Arrange
        DateTime value = DateTime.Now;

        // Act
        Action action = () => value.Throw().IfDefault();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotDefault_WhenValueIsNotDefault_ShouldThrow()
    {
        // Arrange
        DateTime value = DateTime.Now;

        // Act
        Action action = () => value.Throw().IfNotDefault();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be default. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotDefault_WhenValueIsDefault_ShouldNotThrow()
    {
        // Arrange
        DateTime value = default;

        // Act
        Action action = () => value.Throw().IfNotDefault();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEquals_WhenValueEquals_ShouldThrow()
    {
        // Arrange
        int value = 5;

        // Act
        Action action = () => value.Throw().IfEquals(5);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be equal to 5. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfEquals_WhenValueIsNotEqual_ShouldNotThrow()
    {
        // Arrange
        int value = 5;

        // Act
        Action action = () => value.Throw().IfEquals(6);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenNotEquals_ShouldThrow()
    {
        // Arrange
        int value = 5;

        // Act
        Action action = () => value.Throw().IfNotEquals(6);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be equal to 6. (Parameter '{nameof(value)}')");
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenEquals_ShouldNotThrow()
    {
        // Arrange
        int value = 5;

        // Act
        Action action = () => value.Throw().IfNotEquals(5);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEquals_WhenObjectReferenceEquals_ShouldThrow()
    {
        // Arrange
        var value1 = new object();
        var value2 = value1;

        // Act
        Action action = () => value1.Throw().IfEquals(value2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be equal to {value2}. (Parameter '{nameof(value1)}')");
    }

    [TestMethod]
    public void ThrowIfEquals_WhenObjectReferenceIsNotEqual_ShouldNotThrow()
    {
        // Arrange
        var value1 = new object();
        var value2 = new object();

        // Act
        Action action = () => value1.Throw().IfEquals(value2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenObjectReferenceIsNotEqual_ShouldThrow()
    {
        // Arrange
        var value1 = new object();
        var value2 = new object();

        // Act
        Action action = () => value1.Throw().IfNotEquals(value2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be equal to {value2}. (Parameter '{nameof(value1)}')");
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenObjectReferenceEquals_ShouldNotThrow()
    {
        // Arrange
        var value1 = new object();
        var value2 = value1;

        // Act
        Action action = () => value1.Throw().IfNotEquals(value2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfEquals_WhenOverrideEqualsTypeEquals_ShouldThrow()
    {
        // Arrange
        var value1 = new OverrideEqualsType(1);
        var value2 = new OverrideEqualsType(1);

        // Act
        Action action = () => value1.Throw().IfEquals(value2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should not be equal to {value2}. (Parameter '{nameof(value1)}')");
    }

    [TestMethod]
    public void ThrowIfEquals_WhenOverridequalsTypeIsNotEqual_ShouldNotThrow()
    {
        // Arrange
        var value1 = new OverrideEqualsType(1);
        var value2 = new OverrideEqualsType(2);

        // Act
        Action action = () => value1.Throw().IfEquals(value2);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenOverridequalsTypeIsNotEqual_ShouldThrow()
    {
        // Arrange
        var value1 = new OverrideEqualsType(1);
        var value2 = new OverrideEqualsType(2);

        // Act
        Action action = () => value1.Throw().IfNotEquals(value2);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Value should be equal to {value2}. (Parameter '{nameof(value1)}')");
    }

    [TestMethod]
    public void ThrowIfNotEquals_WhenOverridequalsTypeEquals_ShouldNotThrow()
    {
        // Arrange
        var value1 = new OverrideEqualsType(1);
        var value2 = new OverrideEqualsType(1);

        // Act
        Action action = () => value1.Throw().IfNotEquals(value2);

        // Assert
        action.Should().NotThrow();
    }

    private class OverrideEqualsType
    {
        public OverrideEqualsType(int id) => this.Id = id;

        public int Id { get; }

        public override bool Equals(object? obj)
        {
            if (obj is not OverrideEqualsType other)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}