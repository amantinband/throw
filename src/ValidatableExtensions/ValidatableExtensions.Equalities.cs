namespace Throw;

/// <summary>
/// Extension methods for equalities.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the value is equal to the default value of type <typeparamref name="TValue"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfDefault<TValue>(this in Validatable<TValue> validatable)
        where TValue : struct, IComparable
    {
        Validator.ThrowIfEquals(
            validatable.Value,
            default,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            "Value should not be default.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the value is not equal to the default value of type <typeparamref name="TValue"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotDefault<TValue>(this in Validatable<TValue> validatable)
        where TValue : struct, IComparable
    {
        Validator.ThrowIfNotEquals(
            validatable.Value,
            default,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            "Value should be default.");

        return ref validatable;
    }
}