namespace Throw.UnitTests.Common;

[TestClass]
public class ValidatableTests
{
    [TestMethod]
    public void CastValidatable_WhenToOriginalType_ShouldReturnOriginalValue()
    {
        // Arrange
        string value = "value";

        // Act
        string castedValue = value.Throw();

        // Assert
        castedValue.Should().Be(value);
    }

    [TestMethod]
    public void UpdateExceptionCustomization_WhenToDefault_ShouldReturnValidatableWithDefaultCustomization()
    {
        // Arrange
        string value = "value";
        var validatable = value.Throw("custom message"); // some customization.

        // Act
        Validatable<string> result = validatable.Throw(); // reset back to default.

        // Assert
        result.ExceptionCustomizations.Should().BeNull();
    }

    [TestMethod]
    public void UpdateExceptionCustomization_WhenToCustomMessage_ShouldReturnValidatableWithCustomMessageCustomization()
    {
        // Arrange
        string value = "value";
        var validatable = value.Throw(); // no customization.

        // Act
        Validatable<string> result = validatable.Throw("custom message"); // update to custom message.

        // Assert
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<string>()
            .Subject.Should().BeSameAs("custom message");
    }

    [TestMethod]
    public void UpdateExceptionCustomization_WhenToCustomThrower_ShouldReturnValidatableWithCustomThrowerCustomization()
    {
        // Arrange
        string value = "value";
        var validatable = value.Throw(); // no customization.
        var exceptionThrower = () => new Exception();

        // Act
        Validatable<string> result = validatable.Throw(exceptionThrower); // update to custom thrower.

        // Assert
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
    }

    [TestMethod]
    public void UpdateExceptionCustomization_WhenToCustomThrowerWithParamName_ShouldReturnValidatableWithCustomThrowerCustomization()
    {
        // Arrange
        string value = "value";
        var validatable = value.Throw(); // no customization.
        Func<string, Exception> exceptionThrower = paramName => new Exception($"param: {paramName}");

        // Act
        Validatable<string> result = validatable.Throw(exceptionThrower); // update to custom thrower.

        // Assert
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<string, Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
    }

    [TestMethod]
    public void UpdateExceptionCustomization_WhenToExceptionType_ShouldReturnValidatableWithExceptionTypeCustomization()
    {
        // Arrange
        string value = "value";
        var validatable = value.Throw(); // no customization.

        // Act
        Validatable<string> result = validatable.Throw<InvalidOperationException>(); // update to custom exception type.

        // Assert
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeSameAs(typeof(InvalidOperationException));
    }
}