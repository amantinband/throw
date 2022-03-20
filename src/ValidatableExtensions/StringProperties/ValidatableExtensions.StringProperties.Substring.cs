namespace Throw;

/// <summary>
/// Extension methods for string properties.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> ends with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEndsWith<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfEndsWith(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not end with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEndsWith<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotEndsWith(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> starts with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfStartsWith<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfStartsWith(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not start with <paramref name="str"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotStartsWith<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string str,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotStartsWith(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            str,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> contains the given <paramref name="otherString"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfContains<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string otherString,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfContains(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            otherString,
            comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string returned from the given <paramref name="func"/> does not contain the given <paramref name="otherString"/>.
    /// Default <paramref name="comparisonType"/> is <see cref="StringComparison.Ordinal"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotContains<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, string> func,
        string otherString,
        StringComparison comparisonType = StringComparison.Ordinal,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotContains(
            func(validatable.Value),
            $"{validatable.ParamName}: {funcName}",
            validatable.ExceptionCustomizations,
            otherString,
            comparisonType);

        return ref validatable;
    }

}