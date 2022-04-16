namespace Throw.UnitTests.ValidatableCreation;

using OneOf;

[TestClass]
public class ValidatableCreationExtensionsTests
{
    [TestMethod]
    public void CreateThrowable_WhenNoCustomizations_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        var value = "value";

        // Act
        Validatable<string> result = value.Throw();

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().BeNull();
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowable_WhenCustomExceptionMessage_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        var value = "value";

        // Act
        Validatable<string> result = value.Throw(ParameterConstants.CustomMessage);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<string>()
            .Subject.Should().BeSameAs(ParameterConstants.CustomMessage);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowable_WhenCustomExceptionThrower_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        var value = "value";
        var exceptionThrower = () => new Exception();

        // Act
        Validatable<string> result = value.Throw(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowable_WhenCustomExceptionThrowerWithParamName_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        var value = "value";
        Func<string, Exception> exceptionThrower = paramName => new Exception($"param: {paramName}");

        // Act
        Validatable<string> result = value.Throw(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<string, Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowable_WhenOneOfDiscriminatedUnion_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        var value = "value";
        OneOf<string, Type, Func<Exception>, Func<string, Exception>> customizations = ParameterConstants.CustomMessage;

        // Act
        Validatable<string> result = value.Throw(customizations);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<string>()
            .Subject.Should().BeSameAs(ParameterConstants.CustomMessage);
        result.ParamName.Should().Be(nameof(value));
    }
}