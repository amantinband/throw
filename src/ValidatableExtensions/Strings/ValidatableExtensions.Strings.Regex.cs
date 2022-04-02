using System.Text.RegularExpressions;

namespace Throw;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string matches the given <paramref name="regexPattern"/>.
    /// Default <paramref name="regexOptions"/> is <see cref="RegexOptions.None"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfMatches(
        this in Validatable<string> validatable,
        string regexPattern,
        RegexOptions regexOptions = RegexOptions.None)
    {
        Validator.ThrowIfMatches(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            regexPattern,
            regexOptions);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string matches the given <paramref name="regex"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfMatches(this in Validatable<string> validatable, Regex regex)
    {
        Validator.ThrowIfMatches(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, regex);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not match the given <paramref name="regexPattern"/>.
    /// Default <paramref name="regexOptions"/> is <see cref="RegexOptions.None"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotMatches(
        this in Validatable<string> validatable,
        string regexPattern,
        RegexOptions regexOptions = RegexOptions.None)
    {
        Validator.ThrowIfNotMatches(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            regexPattern,
            regexOptions);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not match the given <paramref name="regex"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotMatches(this in Validatable<string> validatable, Regex regex)
    {
        Validator.ThrowIfNotMatches(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            regex);

        return ref validatable;
    }
}