namespace Throw;

/// <summary>
/// Extension methods for comparable properties (int, double, decimal, long, float, short, DateTime, DateOnly, TimeOnly etc.).
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is greater than <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfGreaterThan<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult n,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TResult : notnull, IComparable
    {
        Validator.ThrowIfGreaterThan(
            value: func(validatable.Value),
            other: n,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is less than <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLessThan<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult n,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : IComparable
    {
        Validator.ThrowIfLessThan(
            value: func(validatable.Value),
            other: n,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is equal to <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEquals<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult n,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull
    {
        Validator.ThrowIfEquals(
            value: func(validatable.Value),
            other: n,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is not equal to <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEquals<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult n,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull
    {
        Validator.ThrowIfNotEquals(
            value: func(validatable.Value),
            other: n,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is greater than 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfPositive<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull, IComparable
    {
        Validator.ThrowIfGreaterThan(
            value: func(validatable.Value),
            other: default!,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is less than 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNegative<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull, IComparable
    {
        Validator.ThrowIfLessThan(
            value: func(validatable.Value),
            other: default!,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value returned from the given <paramref name="func"/> is not between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="validatable">The validatable being validated.</param>
    /// <param name="func">A function that will be applied on the value.</param>
    /// <param name="min">The minimum value, inclusive (equals or greater than).</param>
    /// <param name="max">The maximum value, inclusive (equals or less than).</param>
    /// <param name="funcName">Doesn't need to be specified. Will be populated by the compiler.</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfOutOfRange<TValue, TResult>(
        this in Validatable<TValue> validatable,
        Func<TValue, TResult> func,
        TResult min,
        TResult max,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TResult : notnull, IComparable
    {
        Validator.ThrowIfNotInRange(
            value: func(validatable.Value),
            min: min,
            max: max,
            paramName: $"{validatable.ParamName}: {funcName}",
            exceptionCustomizations: validatable.ExceptionCustomizations);

        return ref validatable;
    }
}