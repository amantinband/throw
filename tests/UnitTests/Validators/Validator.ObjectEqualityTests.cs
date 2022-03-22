using System.Collections.Generic;
using System.Linq;

namespace Throw.UnitTests.Validators;

[TestClass]
public class ObjectEqualityValidatorTests
{
    class EquatableType : IEquatable<EquatableType>
    {
        public EquatableType(int id)
        {
            Id = id;
        }

        public int Id { get; init; }

        public bool Equals(EquatableType? other)
        {
            if (other is null) return false;
            return Id == other.Id;
        }
    }

    class GeneriComparableType : IComparable<GeneriComparableType>
    {
        public GeneriComparableType(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public int CompareTo(GeneriComparableType? other)
        {
            return Id.CompareTo(other?.Id);
        }

    }

    class ComparableType : IComparable
    {
        public ComparableType(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public int CompareTo(object? obj)
        {
            var other = obj as ComparableType;
            return Id.CompareTo(other?.Id);
        }
    }

    class OverrideDefaultEqualsType
    {
        public OverrideDefaultEqualsType(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            var other = obj as OverrideDefaultEqualsType;
            if (other is null) return false;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    [TestMethod]
    public void IsEqual_WhenObjectTypeIsIEquatableAndEqual_ShouldBeEqual()
    {
        // Arrange
        EquatableType value = new(1), other = new(1);

        // Act
        var valdatorResult = Validator.IsEqual(value, other);

        // Assert
        valdatorResult.Should().Be(true);
    }


    [TestMethod]
    public void IsEqual_WhenObjectTypeIsIEquatableAndNotEqual_ShouldNotBeEqual()
    {
        // Arrange
        EquatableType value = new(1), other = new(2);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(false);
    }

    [TestMethod]
    public void IsEqual_WhenObjectTypeIsGenericIComparableAndEqual_ShouldBeEqual()
    {
        // Arrange
        GeneriComparableType value = new(1), other = new(1);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(true);
    }

    [TestMethod]
    public void IsEqual_WhenObjectTypeIsGenericIComparableAndNotEqual_ShouldNotBeEqual()
    {
        // Arrange
        GeneriComparableType value = new(1), other = new(2);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(false);
    }

    [TestMethod]
    public void IsEqual_WhenObjectTypeIsIComparableAndEqual_ShouldBeEqual()
    {
        // Arrange
        ComparableType value = new(1), other = new(1);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(true);
    }

    [TestMethod]
    public void IsEqual_WhenObjectTypeIsIComparableAndNotEqual_ShouldNotBeEqual()
    {
        // Arrange
        ComparableType value = new(1), other = new(2);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(false);
    }

    [TestMethod]
    public void IsEqual_WhenObectOverridesDefaultEqualsAndEqual_ShouldBeEqual()
    {
        // Arrange
        OverrideDefaultEqualsType value = new(1), other = new(1);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(true);
    }

    [TestMethod]
    public void IsEqual_WhenObjectOverridesDefaultEqualsAndNotEqual_ShouldNotBeEqual()
    {
        // Arrange
        OverrideDefaultEqualsType value = new(1), other = new(2);

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(false);
    }

    [TestMethod]
    public void IsEqual_WhenObjectHasSameRef_ShouldBeEqual()
    {
        // Arrange
        object value = new(), other = value;

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(true);
    }

    [TestMethod]
    public void IsEqual_WhenObjectHasDifferentRef_ShouldNotBeEqual()
    {
        // Arrange
        object value = new(), other = new();

        // Act
        var isEqual = Validator.IsEqual(value, other);

        // Assert
        isEqual.Should().Be(false);
    }
}
