namespace Throw;

public readonly partial record struct Validatable<TValue>
{
    /// <summary>
    /// Throws an exception if type of the value is <see cref="T:T"/>
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfType<T>()
    {
        Validator.ThrowIfType<T>(
            typeof(TValue),
            ParamName,
            ExceptionCustomizations);
        return this;
    }

    /// <summary>
    /// Throws an exception if type of the value is not <see cref="T:T"/>
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Validatable<TValue> IfNotType<T>()
    {
        Validator.ThrowIfNotType<T>(
            typeof(TValue),
            ParamName,
            ExceptionCustomizations);
        return this;
    }
}