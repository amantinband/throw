namespace Throw;

/// <summary>
/// Extension methods for string properties.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is white space only.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfWhiteSpace<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, [CallerArgumentExpression("func")] string? funcName = null)
       where TValue : notnull
    {
        Validator.ThrowIfWhiteSpace(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is empty.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEmpty<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEmpty(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is null or empty.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNullOrEmpty<TValue>(this in Validatable<TValue> validatable, Func<TValue, string?> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNullOrEmpty(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is null or whitespace.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNullOrWhiteSpace<TValue>(this in Validatable<TValue> validatable, Func<TValue, string?> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNullOrWhiteSpace(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is longer than <paramref name="length"/> characters.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLongerThan<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, int length, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfLongerThan(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> is shorter than <paramref name="length"/> characters.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfShorterThan<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, int length, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfShorterThan(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> equals the given <paramref name="otherString"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="StringComparison"/> used is <see cref="StringComparison.Ordinal"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString, StringComparison.Ordinal);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> equals the given <paramref name="otherString"/> using the given <paramref name="comparisonType"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, StringComparison comparisonType, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString, comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not equal the given <paramref name="otherString"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="StringComparison"/> used is <see cref="StringComparison.Ordinal"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString, StringComparison.Ordinal);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the <paramref name="func"/> does not equal the <paramref name="otherString"/> using the given <paramref name="comparisonType"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, StringComparison comparisonType, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString, comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> equals the given <paramref name="otherString"/> (case insensitive).
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEqualsIgnoreCase<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEqualsIgnoreCase(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not equal the given <paramref name="otherString"/> (case insensitive).
    /// </summary>
    /// <remarks>
    /// The default <see cref="StringComparison"/> type is <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEqualsIgnoreCase<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString, StringComparison.OrdinalIgnoreCase);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the length of string returned from the given <paramref name="func"/> is equal to <paramref name="length"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLengthEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, int length, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfLengthEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the length of string returned from the given <paramref name="func"/> is not equal to <paramref name="length"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfLengthNotEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, int length, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfLengthNotEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> ends with <paramref name="str"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEndsWith<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string str, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEndsWith(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, str);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not end with <paramref name="str"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEndsWith<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string str, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEndsWith(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, str);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> starts with <paramref name="str"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfStartsWith<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string str, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfStartsWith(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, str);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not start with <paramref name="str"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotStartsWith<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string str, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotStartsWith(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, str);

        return ref validatable;
    }
}