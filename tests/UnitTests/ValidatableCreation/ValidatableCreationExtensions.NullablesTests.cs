namespace Throw.UnitTests.ValidatableCreation;

[TestClass]
public class ValidatableCreationExtensionsNullablesTests
{
    [TestMethod]
    public void CreateThrowableFromNullable_WhenNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        string? value = null;

        // Act
        Action action = () => value.ThrowIfNull();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void CreateThrowableFromNullable_WhenNoCustomizations_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        string? value = "value";

        // Act
        Validatable<string> result = value.ThrowIfNull();

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().BeNull();
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromNullable_WhenCustomExceptionMessage_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        string? value = "value";

        // Act
        Validatable<string> result = value.ThrowIfNull(ParameterConstants.CustomMessage);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<string>()
            .Subject.Should().BeSameAs(ParameterConstants.CustomMessage);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromNullable_WhenCustomExceptionThrower_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        string? value = "value";
        var exceptionThrower = () => new Exception();

        // Act
        Validatable<string> result = value.ThrowIfNull(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromNullable_WhenCustomExceptionThrowerWithParamName_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        string? value = "value";
        Func<string, Exception> exceptionThrower = paramName => new Exception($"param: {paramName}");

        // Act
        Validatable<string> result = value.ThrowIfNull(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<string, Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromValueTypeNullable_WhenNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        int? value = null;

        // Act
        Action action = () => value.ThrowIfNull();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [TestMethod]
    public void CreateThrowableFromValueTypeNullable_WhenNoCustomizations_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        int? value = 5;

        // Act
        Validatable<int> result = value.ThrowIfNull();

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().BeNull();
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromValueTypeNullable_WhenCustomExceptionMessage_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        int? value = 5;

        // Act
        Validatable<int> result = value.ThrowIfNull(ParameterConstants.CustomMessage);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<string>()
            .Subject.Should().BeSameAs(ParameterConstants.CustomMessage);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromValueTypeNullable_WhenCustomExceptionThrower_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        int? value = 5;
        var exceptionThrower = () => new Exception();

        // Act
        Validatable<int> result = value.ThrowIfNull(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }

    [TestMethod]
    public void CreateThrowableFromValueTypeNullable_WhenCustomExceptionThrowerWithParamName_ShouldCreateCorrespondingThrowarble()
    {
        // Arrange
        int? value = 5;
        Func<string, Exception> exceptionThrower = paramName => new Exception($"param: {paramName}");

        // Act
        Validatable<int> result = value.ThrowIfNull(exceptionThrower);

        // Assert
        result.Value.Should().Be(value);
        result.ExceptionCustomizations.Should().NotBeNull();
        result.ExceptionCustomizations!.Value.Customization.Value
            .Should().BeOfType<Func<string, Exception>>()
            .Subject.Should().BeSameAs(exceptionThrower);
        result.ParamName.Should().Be(nameof(value));
    }
}