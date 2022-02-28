namespace Throw;

public static partial class ValidatableCreationExtensions
{
    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable value type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionThrower">A function which returns an excpetion. This function will be used to create the exception that will be thrown if a condition is matched.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// This extension method is intended for nullable value types.
    /// For general nullable types, use the <see cref="ThrowIfNull{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, Func<string, Exception> exceptionThrower, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : struct
    {
        return value.ThrowIfNull(exceptionCustomizations: exceptionThrower, paramName: paramName);
    }

    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable value type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionThrower">
    /// A function which receives the parameter name returns an excpetion.
    /// This function will be used to create the exception that will be thrown if a condition is matched.
    /// For example: <c>paramName => throw new Exception($"Parameter name: {paramName}")</c>
    /// </param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// This extension method is intended for nullable value types.
    /// For general nullable types, use the <see cref="ThrowIfNull{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, Func<Exception> exceptionThrower, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : struct
    {
        return value.ThrowIfNull(exceptionCustomizations: exceptionThrower, paramName: paramName);
    }

    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable value type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionCustomizations">Exception customizations. This can be used to supply a custom exception message which will be used instead of the default message.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// This extension method is intended for nullable value types.
    /// For general nullable types, use the <see cref="ThrowIfNull{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, ExceptionCustomizations? exceptionCustomizations = null, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : struct
    {
        if (value == null)
        {
            ExceptionThrower.ThrowNull(paramName!, exceptionCustomizations);
        }

        return new Validatable<TValue>(value.Value, paramName!, exceptionCustomizations);
    }

    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionThrower">A function which returns an excpetion. This function will be used to create the exception that will be thrown if a condition is matched.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// This extension method is intended for general nullable types.
    /// For nullable value types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, Func<string, Exception> exceptionThrower, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull
    {
        return value.ThrowIfNull(exceptionCustomizations: exceptionThrower, paramName: paramName);
    }

    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionThrower">
    /// A function which receives the parameter name returns an excpetion.
    /// This function will be used to create the exception that will be thrown if a condition is matched.
    /// For example: <c>paramName => throw new Exception($"Parameter name: {paramName}")</c>
    /// </param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// This extension method is intended for general nullable types.
    /// For nullable value types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, Func<Exception> exceptionThrower, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull
    {
        return value.ThrowIfNull(exceptionCustomizations: exceptionThrower, paramName: paramName);
    }

    /// <summary>
    /// Throws an exception if the <paramref name="value"/> is null.
    /// Otherwise, creates a new <see cref="Validatable{TValue}"/> instance with the specified value, where the type is the non-nullable type of the given nullable value type <see cref="{TValue}"/>.
    /// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
    /// </summary>
    /// <param name="value">The nullable value to be validated.</param>
    /// <param name="exceptionCustomizations">Exception customizations. This can be used to supply a custom exception message which will be used instead of the default message.</param>
    /// <param name="paramName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// This extension method is intended general nullable types.
    /// For nullable value types, use the <see cref="ThrowIfNull{TValue}(TValue?, ExceptionCustomizations?, string?)"/> extension method.
    /// For non-nullable types, use the <see cref="Throw{TValue}(TValue, ExceptionCustomizations?, string?)"/> extension method.
    /// </remarks>
    [Pure, JetBrainsNotNull, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Validatable<TValue> ThrowIfNull<TValue>([NotNull, AllowNull, JetBrainsCanBeNull] this TValue? value, ExceptionCustomizations? exceptionCustomizations = null, [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull
    {
        if (value == null)
        {
            ExceptionThrower.ThrowNull(paramName!, exceptionCustomizations);
        }

        return new Validatable<TValue>(value!, paramName!, exceptionCustomizations);
    }
}