namespace Throw;

/// <summary>
/// Extension methods for strings.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the string is longer than <paramref name="length"/> characters.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfLongerThan(this in Validatable<string> validatable, int length)
    {
        Validator.ThrowIfLongerThan(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string is shortter than <paramref name="length"/> characters.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfShorterThan(this in Validatable<string> validatable, int length)
    {
        Validator.ThrowIfShorterThan(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string length is equal to <paramref name="length"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfLengthEquals(this in Validatable<string> validatable, int length)
    {
        Validator.ThrowIfLengthEquals(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            length);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the string length is not equal to <paramref name="length"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<string> IfLengthNotEquals(
        this in Validatable<string> validatable,
        int length)
    {
        Validator.ThrowIfLengthNotEquals(
            validatable.Value,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            length);

        return ref validatable;
    }
}