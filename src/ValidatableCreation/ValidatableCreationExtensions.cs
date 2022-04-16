namespace Throw;

/// <summary>
/// Extensions for creating <see cref="Validatable{TValue}"/>s.
/// </summary>
public static partial class ValidatableCreationExtensions
{
    /// <summary>
    /// Creates a new <see cref="Validatable{TValue}"/> instance with the specified value.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="exceptionThrower">A function which returns an excpetion. This function will be used to create the exception that will be thrown if a condition is matched.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// This extension method is intended for non-nullable types.
    /// For nullable types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> Throw<TValue>(
        [DisallowNull, NotNull] this TValue value,
        Func<Exception> exceptionThrower,
        [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull => new(value, paramName!, exceptionThrower);

    /// <summary>
    /// Creates a new <see cref="Validatable{TValue}"/> instance with the specified value.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="exceptionThrower">
    /// A function which receives the parameter name returns an excpetion.
    /// This function will be used to create the exception that will be thrown if a condition is matched.
    /// For example: <c>paramName => throw new Exception($"Parameter name: {paramName}")</c>.
    /// </param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// This extension method is intended for non-nullable types.
    /// For nullable types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> Throw<TValue>(
        [DisallowNull, NotNull] this TValue value,
        Func<string, Exception> exceptionThrower,
        [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull => new(value, paramName!, exceptionThrower);

    /// <summary>
    /// Creates a new <see cref="Validatable{TValue}"/> instance with the specified value.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="exceptionCustomizations">Exception customizations. This can be used to supply a custom exception message which will be used instead of the default message.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// This extension method is intended for non-nullable types.
    /// For nullable types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> Throw<TValue>(
        [DisallowNull, NotNull] this TValue value,
        ExceptionCustomizations? exceptionCustomizations = null,
        [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull => new(value, paramName!, exceptionCustomizations);
}
