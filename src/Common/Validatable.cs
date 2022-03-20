namespace Throw;

/// <summary>
/// Creates a new <see cref="Validatable{TValue}"/> instance with the specified value.
/// The <see cref="Validatable{TValue}"/> instance can be used to throw exceptions if the value matches a condition specified.
/// </summary>
/// <param name="Value">The value to be validated.</param>
/// <param name="ParamName">The name of the parameter holding the <paramref name="Value"/>.</param>
/// <param name="ExceptionCustomizations">Customizations to the exception, which will be applied if an exception is thrown.</param>
public readonly record struct Validatable<TValue>(TValue Value, string ParamName, ExceptionCustomizations? ExceptionCustomizations = null)
    where TValue : notnull
{
    /// <summary>
    /// Implicit conversion operator back to the original value's type.
    /// </summary>
    public static implicit operator TValue([DisallowNull, JetBrainsNotNull] Validatable<TValue> validatable)
    {
        return validatable.Value;
    }

    /// <summary>
    /// Creates a validatable with the specified <paramref name="message"/> exception customization.
    /// </summary>
    /// <param name="message">A custom exception message which will be used instead of the default message.</param>
    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] string message)
    {
        return this with { ExceptionCustomizations = message };
    }

    /// <summary>
    /// Creates a validatable with the specified <paramref name="exceptionThrower"/> exception customization.
    /// </summary>
    /// <param name="exceptionThrower">
    /// A function which returns an excpetion. This function will be used to create the exception that will
    /// be thrown if a condition is matched.
    /// </param>
    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] Func<Exception> exceptionThrower)
    {
        return this with { ExceptionCustomizations = exceptionThrower };
    }

    /// <summary>
    /// Creates a validatable with the specified <paramref name="exceptionThrower"/> exception customization.
    /// </summary>
    /// <param name="exceptionThrower">
    /// A function which receives the parameter name returns an excpetion.
    /// This function will be used to create the exception that will be thrown if a condition is matched.
    /// For example: <c>paramName => throw new Exception($"Parameter name: {paramName}")</c>
    /// </param>
    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] Func<string, Exception> exceptionThrower)
    {
        return this with { ExceptionCustomizations = exceptionThrower };
    }

    /// <summary>
    /// Creates a validatable with the specified exception customization.
    /// </summary>
    /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
    public Validatable<TValue> Throw<TException>()
        where TException : notnull, Exception, new()
    {
        return this with { ExceptionCustomizations = typeof(TException) };
    }

    /// <summary>
    /// Creates a validatable with the no customizations.
    /// </summary>
    public Validatable<TValue> Throw()
    {
        return this with { ExceptionCustomizations = null };
    }
}
