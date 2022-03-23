namespace Throw;

/// <remarks>
/// Allows to use generic Validatable without type argument.
/// </remarks>
public interface IImplicitlyTypedValidatable
{
    /// <summary>
    /// Type of the validatable value.
    /// </summary>
    Type Type { get; init; }

    /// <summary>
    /// The name of the parameter holding the validatable value.
    /// </summary>
    string ParamName { get; init; }

    /// <summary>
    /// Customizations to the exception, which will be applied if an exception is thrown.
    /// </summary>
    ExceptionCustomizations? ExceptionCustomizations { get; init; }
}