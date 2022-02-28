namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the boolean value is true.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<bool> IfTrue(this in Validatable<bool> validatable)
    {
        if (validatable.Value)
        {
            ExceptionThrower.Throw(validatable.ParamName, validatable.ExceptionCustomizations, "Value should not be true.");
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the boolean value is false.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<bool> IfFalse(this in Validatable<bool> validatable)
    {
        if (!validatable.Value)
        {
            ExceptionThrower.Throw(validatable.ParamName, validatable.ExceptionCustomizations, "Value should be true.");
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <paramref name="condition"/> is true.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfTrue<TValue>(this in Validatable<TValue> validatable, bool condition, [CallerArgumentExpression("condition")] string? conditionParamName = null)
        where TValue : notnull
    {
        if (condition)
        {
            ExceptionThrower.Throw(validatable.ParamName, validatable.ExceptionCustomizations, $"Value should not meet condition (condition: '{conditionParamName}').");
        }

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <paramref name="condition"/> is false.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfFalse<TValue>(this in Validatable<TValue> validatable, bool condition, [CallerArgumentExpression("condition")] string? conditionParamName = null)
        where TValue : notnull
    {
        if (!condition)
        {
            ExceptionThrower.Throw(validatable.ParamName, validatable.ExceptionCustomizations, $"Value should meet condition (condition: '{conditionParamName}').");
        }

        return ref validatable;
    }
}