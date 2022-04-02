namespace Throw;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string ends with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfEndsWith(
        this in Validatable<string> validatable,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfEndsWith(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not end with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotEndsWith(
        this in Validatable<string> validatable,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfNotEndsWith(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string starts with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfStartsWith(
        this in Validatable<string> validatable,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfStartsWith(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not start with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotStartsWith(
        this in Validatable<string> validatable,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfNotStartsWith(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string contains the given <paramref name="otherString"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfContains(
        this in Validatable<string> validatable,
        string otherString,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfContains(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            otherString,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not contain the given <paramref name="otherString"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotContains(
        this in Validatable<string> validatable,
        string otherString,
        StringComparison comparisonType = StringComparison.Ordinal)
    {
        Validator.ThrowIfNotContains(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            otherString,
            comparisonType);

        return ref validatable;
    }
}