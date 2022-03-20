namespace Throw;

/// <summary>
/// Extension methods for boolean properties.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the boolean value returned from the given <paramref name="func"/> is true.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfTrue<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, bool> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        if (func(validatable.Value))
        {
            ExceptionThrower.Throw(
                validatable.ParamName,
                validatable.ExceptionCustomizations,
                $"Value should not meet condition (condition: '{funcName}').");
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the boolean value returned from the given <paramref name="func"/> is false.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfFalse<TValue>(
        this in Validatable<TValue> validatable,
        Func<TValue, bool> func,
        [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        if (!func(validatable.Value))
        {
            ExceptionThrower.Throw(
                validatable.ParamName,
                validatable.ExceptionCustomizations,
                $"Value should meet condition (condition: '{funcName}').");
        }

        return ref validatable;
    }
}