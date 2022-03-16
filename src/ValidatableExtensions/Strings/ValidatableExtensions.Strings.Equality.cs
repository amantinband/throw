namespace Throw;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string is white space only.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfWhiteSpace(this in Validatable<string> validatable)
    {
        Validator.ThrowIfWhiteSpace(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string is empty.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfEmpty(this in Validatable<string> validatable)
    {
        Validator.ThrowIfEmpty(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string equals the given <paramref name="otherString"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="StringComparison"/> used is <see cref="StringComparison.Ordinal"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfEquals(this in Validatable<string> validatable, string otherString)
    {
        Validator.ThrowIfEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, StringComparison.Ordinal);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string equals the given <paramref name="otherString"/> using the given <paramref name="comparisonType"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfEquals(this in Validatable<string> validatable, string otherString, StringComparison comparisonType)
    {
        Validator.ThrowIfEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not equal the given <paramref name="otherString"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="StringComparison"/> used is <see cref="StringComparison.Ordinal"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotEquals(this in Validatable<string> validatable, string otherString)
    {
        Validator.ThrowIfNotEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, StringComparison.Ordinal);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not equal the <paramref name="otherString"/> using the given <paramref name="comparisonType"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotEquals(this in Validatable<string> validatable, string otherString, StringComparison comparisonType)
    {
        Validator.ThrowIfNotEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, comparisonType);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string equals the given <paramref name="otherString"/> (case insensitive).
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfEqualsIgnoreCase(this in Validatable<string> validatable, string otherString)
    {
        Validator.ThrowIfEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, StringComparison.OrdinalIgnoreCase);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string does not equal the given <paramref name="otherString"/> (case insensitive).
    /// </summary>
    /// <remarks>
    /// The <see cref="StringComparison"/> used is <see cref="StringComparison.OrdinalIgnoreCase"/>.
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfNotEqualsIgnoreCase(this in Validatable<string> validatable, string otherString)
    {
        Validator.ThrowIfNotEquals(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations, otherString, StringComparison.OrdinalIgnoreCase);

        return ref validatable;
    }
}