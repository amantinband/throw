namespace Throw;

/// <summary>
/// Methods for <typeparamref name="TValue"/>.
/// </summary>
public readonly partial record struct Validatable<TValue>
{
    /// <summary>
    /// Throws an exception if <typeparamref name="TValue"/>'s runtime type equals <typeparamref name="TOther"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfType<TOther>()
    {
        Validator.ThrowIfTypesEqual(
            Value.GetType(),
            typeof(TOther),
            ParamName,
            ExceptionCustomizations);

        return this;
    }

    /// <summary>
    /// Throws an exception if <typeparamref name="TValue"/>'s runtime type does not equal <typeparamref name="TOther"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfNotType<TOther>()
    {
        Validator.ThrowIfTypesNotEqual(
            Value.GetType(),
            typeof(TOther),
            ParamName,
            ExceptionCustomizations);

        return this;
    }
}
