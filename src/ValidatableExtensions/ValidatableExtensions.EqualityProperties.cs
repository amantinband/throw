namespace Throw;

/// <summary>
/// Extension methods for property equalities.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is equal to null.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNull<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        if (func(validatable.Value) is null)
        {
            ExceptionThrower.ThrowNull($"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is not equal to null.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentNullException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotNull<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        if (func(validatable.Value) is not null)
        {
            ExceptionThrower.Throw($"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, "Value should be null.");
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is equal to the default value of type <typeparamref name="TValue"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfDefault<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TResult : struct
    {
        Validator.ThrowIfEquals(
            func(validatable.Value),
            default,
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            "Value should not be default.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is not equal to the default value of type <typeparamref name="TValue"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotDefault<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TResult : struct
    {
        Validator.ThrowIfNotEquals(
            func(validatable.Value),
            default,
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            "Value should be default.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is equal to <paramref name="other"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEquals<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult other,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull
    {
        Validator.ThrowIfEquals(
            value: func(validatable.Value),
            other: other,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is not equal to <paramref name="other"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEquals<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult other,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull
    {
        Validator.ThrowIfNotEquals(
            value: func(validatable.Value),
            other: other,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }
}