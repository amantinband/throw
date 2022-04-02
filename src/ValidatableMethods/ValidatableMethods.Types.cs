namespace Throw;

/// <summary>
/// Methods for <typeparamref name="TValue"/>.
/// </summary>
public readonly partial record struct Validatable<TValue>
{
    /// <summary>
    /// Throws an exception if <typeparamref name="TValue"/> equals <typeparamref name="TOther"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfType<TOther>()
    {
        Validator.ThrowIfTypesEqual(
            typeof(TValue),
            typeof(TOther),
            ParamName,
            ExceptionCustomizations);

        return this;
    }

    /// <summary>
    /// Throws an exception if <typeparamref name="TValue"/> does not equal <typeparamref name="TOther"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfNotType<TOther>()
    {
        Validator.ThrowIfTypesNotEqual(
            typeof(TValue),
            typeof(TOther),
            ParamName,
            ExceptionCustomizations);

        return this;
    }
}