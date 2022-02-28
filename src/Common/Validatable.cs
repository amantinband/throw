namespace Throw;

public readonly record struct Validatable<TValue>(TValue Value, string ParamName, ExceptionCustomizations? ExceptionCustomizations = null) where TValue : notnull
{
    public static implicit operator TValue([DisallowNull, JetBrainsNotNull] Validatable<TValue> validatable)
    {
        return validatable.Value;
    }

    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] string message)
    {
        return this with { ExceptionCustomizations = message };
    }

    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] Func<Exception> exceptionThrower)
    {
        return this with { ExceptionCustomizations = exceptionThrower };
    }

    public Validatable<TValue> Throw([DisallowNull, JetBrainsNotNull] Func<string, Exception> exceptionThrower)
    {
        return this with { ExceptionCustomizations = exceptionThrower };
    }

    public Validatable<TValue> Throw<TException>()
        where TException : notnull, Exception, new()
    {
        return this with { ExceptionCustomizations = typeof(TException) };
    }

    public Validatable<TValue> Throw()
    {
        return this with { ExceptionCustomizations = null };
    }
}
