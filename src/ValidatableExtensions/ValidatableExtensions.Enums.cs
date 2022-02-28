namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the enum value is not defined in the enum.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfOutOfRange<TValue>(this in Validatable<TValue> validatable)
        where TValue : struct, Enum
    {
        Validator.ThrowIfOutOfRange(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }
}