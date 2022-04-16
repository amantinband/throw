namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class EnumPropertiesTests
{
    [TestMethod]
    public void ThrowIfEnumPropertyOutOfRange_WhenValueIsOutOfRange_ShouldThrow()
    {
        // Arrange
        var person = new { PersonType = (PersonType)10 };

        // Act
        Action action = () => person.Throw().IfOutOfRange(p => p.PersonType);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should be defined in enum. (Parameter '{nameof(person)}: p => p.PersonType')\nActual value was {person.PersonType}.");
    }

    [TestMethod]
    public void ThrowIfEnumPropertyOutOfRange_WhenValueIsInRange_ShouldNotThrow()
    {
        // Arrange
        var person = new { PersonType = PersonType.NotFunny };

        // Act
        Action action = () => person.Throw().IfOutOfRange(p => p.PersonType);

        // Assert
        action.Should().NotThrow();
    }

    private enum PersonType
    {
        Funny,
        NotFunny,
    }
}