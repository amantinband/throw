namespace Throw.UnitTests.Common;

[TestClass]
public class ExceptionThrowerTests
{
    [TestMethod]
    public void ThrowNull_WhenNoCustomizations_ShouldThrowArgumentNullException()
    {
        // Act
        Action action = () => ExceptionThrower.ThrowNull(paramName: ParameterConstants.ParamName);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{ParameterConstants.ParamName}')");
    }

    public void ThrowNull_WhenNoCustomizationsButCustomGeneralMessage_ShouldThrowArgumentNullExceptionWithGeneralMessage()
    {
        // Act
        Action action = () => ExceptionThrower.ThrowNull(paramName: ParameterConstants.ParamName, generalMessage: ParameterConstants.CustomMessage);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')");
    }

    [TestMethod]
    public void ThrowNull_WhenCustomExceptionMessage_ShouldThrowArgumentNullExceptionWithCustomMessage()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = ParameterConstants.CustomMessage;

        // Act
        Action action = () => ExceptionThrower.ThrowNull(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')");
    }

    [TestMethod]
    public void ThrowNull_WhenCustomExceptionType_ShouldThrowCustomExceptionType()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = typeof(Exception);

        // Act
        Action action = () => ExceptionThrower.ThrowNull(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>();
    }

    [TestMethod]
    public void ThrowNull_WhenCustomExceptionThrower_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<Exception>)(() => new Exception(ParameterConstants.CustomMessage));

        // Act
        Action action = () => ExceptionThrower.ThrowNull(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage(ParameterConstants.CustomMessage);
    }

    [TestMethod]
    public void ThrowNull_WhenCustomExceptionThrowerWithParamName_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<string, Exception>)(paramName => new Exception($"param: {paramName}"));

        // Act
        Action action = () => ExceptionThrower.ThrowNull(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage($"param: {ParameterConstants.ParamName}");
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenNoCustomizations_ShouldThrowOutOfRangeException()
    {
        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(paramName: ParameterConstants.ParamName, actualValue: ParameterConstants.ActualValue);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage($"Specified argument was out of the range of valid values. (Parameter '{ParameterConstants.ParamName}')\nActual value was {ParameterConstants.ActualValue}.");
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenNoCustomizationsBugCustomGeneralMessage_ShouldThrowOutOfRangeExceptionWithGeneralMessage()
    {
        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(paramName: ParameterConstants.ParamName, actualValue: ParameterConstants.ActualValue, generalMessage: ParameterConstants.CustomMessage);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')\nActual value was {ParameterConstants.ActualValue}.");
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenCustomExceptionMessage_ShouldThrowArgumentNullExceptionWithCustomMessage()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = ParameterConstants.CustomMessage;

        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(ParameterConstants.ParamName, ParameterConstants.ActualValue, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')\nActual value was {ParameterConstants.ActualValue}.");
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenCustomExceptionType_ShouldThrowCustomExceptionType()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = typeof(Exception);

        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(ParameterConstants.ParamName, ParameterConstants.ActualValue, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>();
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenCustomExceptionThrower_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<Exception>)(() => new Exception(ParameterConstants.CustomMessage));

        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(ParameterConstants.ParamName, ParameterConstants.ActualValue, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage(ParameterConstants.CustomMessage);
    }

    [TestMethod]
    public void ThrowOutOfRange_WhenCustomExceptionThrowerWithParamName_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<string, Exception>)(paramName => new Exception($"param: {paramName}"));

        // Act
        Action action = () => ExceptionThrower.ThrowOutOfRange(ParameterConstants.ParamName, ParameterConstants.ActualValue, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage($"param: {ParameterConstants.ParamName}");
    }

    [TestMethod]
    public void Throw_WhenNoCustomizations_ShouldThrowArgumentException()
    {
        // Act
        Action action = () => ExceptionThrower.Throw(paramName: ParameterConstants.ParamName);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"Value does not fall within the expected range. (Parameter '{ParameterConstants.ParamName}')");
    }

    [TestMethod]
    public void Throw_WhenNoCustomizationsButCustomGeneralMessage_ShouldThrowArgumentExceptionWithGeneralMessage()
    {
        // Act
        Action action = () => ExceptionThrower.Throw(paramName: ParameterConstants.ParamName, generalMessage: ParameterConstants.CustomMessage);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')");
    }

    [TestMethod]
    public void Throw_WhenCustomExceptionMessage_ShouldThrowArgumentExceptionWithCustomMessage()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = ParameterConstants.CustomMessage;

        // Act
        Action action = () => ExceptionThrower.Throw(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithMessage($"{ParameterConstants.CustomMessage} (Parameter '{ParameterConstants.ParamName}')");
    }

    [TestMethod]
    public void Throw_WhenCustomExceptionType_ShouldThrowCustomExceptionType()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = typeof(Exception);

        // Act
        Action action = () => ExceptionThrower.Throw(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>();
    }

    [TestMethod]
    public void Throw_WhenCustomExceptionThrower_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<Exception>)(() => new Exception(ParameterConstants.CustomMessage));

        // Act
        Action action = () => ExceptionThrower.Throw(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage(ParameterConstants.CustomMessage);
    }

    [TestMethod]
    public void Throw_WhenCustomExceptionThrowerWithParamName_ShouldThrowUsingCustomExceptionThrower()
    {
        // Arrange
        ExceptionCustomizations exceptionCustomizations = (Func<string, Exception>)(paramName => new Exception($"param: {paramName}"));

        // Act
        Action action = () => ExceptionThrower.Throw(ParameterConstants.ParamName, exceptionCustomizations);

        // Assert
        action.Should().ThrowExactly<Exception>().WithMessage($"param: {ParameterConstants.ParamName}");
    }
}