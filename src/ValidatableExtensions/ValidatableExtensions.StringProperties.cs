namespace Throw;

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
    /// Throws an exception if the string returned from the given <paramref name="func"/> equals the given <paramref name="otherString"/> (case sensitive).
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not equal the given <paramref name="otherString"/> (case sensitive).
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEquals<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEquals(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString);

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
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEqualsIgnoreCase<TValue>(this in Validatable<TValue> validatable, Func<TValue, string> func, string otherString, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEqualsIgnoreCase(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, otherString);

        return ref validatable;
    }
}