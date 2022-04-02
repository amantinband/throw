using System.Text.RegularExpressions;

namespace Throw;

/// <summary>
/// Extension methods for string properties.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> matches the given <paramref name="regexPattern"/>.
    /// Default <paramref name="regexOptions"/> is <see cref="RegexOptions.None"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfMatches<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string regexPattern,
        RegexOptions regexOptions = RegexOptions.None,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfMatches(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            regexPattern,
            regexOptions);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> matches the given <paramref name="regex"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfMatches<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        Regex regex,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfMatches(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            regex);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not match the given <paramref name="regexPattern"/>.
    /// Default <paramref name="regexOptions"/> is <see cref="RegexOptions.None"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotMatches<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string regexPattern,
        RegexOptions regexOptions = RegexOptions.None,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotMatches(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            regexPattern,
            regexOptions);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not match the given <paramref name="regex"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotMatches<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        Regex regex,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotMatches(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            regex);

        return ref validatable;
    }
}