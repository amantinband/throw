namespace Throw;

/// <summary>
/// Extension methods for string properties.
/// </summary>
public static partial class ValidatableExtensions
{
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
}