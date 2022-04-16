namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class EnumsTests
{
    [TestMethod]
    public void ThrowIfEnumOutOfRange_WhenValueIsOutOfRange_ShouldThrow()
    {
        // Arrange
        TestEnum value = (TestEnum)4;

        // Act
        Action action = () => value.Throw().IfOutOfRange();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Value should be defined in enum. (Parameter '{nameof(value)}')\nActual value was {value}.");
    }

    [TestMethod]
    public void ThrowIfEnumOutOfRange_WhenValueIsInRange_ShouldNotThrow()
    {
        // Arrange
        TestEnum value = TestEnum.Value1;

        // Act
        Action action = () => value.Throw().IfOutOfRange();

        // Assert
        action.Should().NotThrow();
    }

    private enum TestEnum
    {
        Value1,
        Value2,
    }
}