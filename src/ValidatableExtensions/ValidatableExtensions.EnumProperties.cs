namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the enum value returned from the given
    /// <paramref name="func"/> is not defined in the enum.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentOutOfRangeException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfOutOfRange<TValue, TEnumValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, TEnumValue> func,
        [CallerArgumentExpression("func")] string? funcName = null)
            where TValue : notnull
            where TEnumValue : struct, Enum
    {
        Validator.ThrowIfOutOfRange(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }
}