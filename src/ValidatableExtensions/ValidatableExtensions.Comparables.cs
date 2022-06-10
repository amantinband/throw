namespace Throw;

/// <summary>
/// Extension methods for comparables (int, double, decimal, long, float, short, DateTime, DateOnly, TimeOnly etc.).
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the value is greater than <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfGreaterThan<TValue>(
        this in Validatable<TValue> validatable,
        TValue n)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfGreaterThan(validatable.Value, n, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is greater than or equal to <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfGreaterThanOrEqualTo<TValue>(
        this in Validatable<TValue> validatable,
        TValue n)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfGreaterThanOrEqualTo(validatable.Value, n, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is less than <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLessThan<TValue>(this in Validatable<TValue> validatable, TValue n)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfLessThan(validatable.Value, n, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is less than or equal to <paramref name="n"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLessThanOrEqualTo<TValue>(this in Validatable<TValue> validatable, TValue n)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfLessThanOrEqualTo(validatable.Value, n, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is greater than 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfPositive<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfGreaterThan(
            validatable.Value,
            default!,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is greater than or equal to 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfPositiveOrZero<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfGreaterThanOrEqualTo(
            validatable.Value,
            default!,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is less than 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNegative<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfLessThan(
            validatable.Value,
            default!,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is less than or equal to 0.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNegativeOrZero<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfLessThanOrEqualTo(
            validatable.Value,
            default!,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is not between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="validatable">The validatable being validated.</param>
    /// <param name="min">The minimum value, inclusive (equals or greater than).</param>
    /// <param name="max">The maximum value, inclusive (equals or less than).</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfOutOfRange<TValue>(
        this in Validatable<TValue> validatable,
        TValue min,
        TValue max)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfNotInRange(
            validatable.Value,
            min,
            max,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="validatable">The validatable being validated.</param>
    /// <param name="min">The minimum value, inclusive (equals or greater than).</param>
    /// <param name="max">The maximum value, inclusive (equals or less than).</param>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfInRange<TValue>(
        this in Validatable<TValue> validatable,
        TValue min,
        TValue max)
        where TValue : notnull, IComparable
    {
        Validator.ThrowIfInRange(
            validatable.Value,
            min,
            max,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }
}
