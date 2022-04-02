namespace Throw;

/// <summary>
/// Exception throwing extensions.
/// </summary>
public static class ExceptionThrower
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/>, unless the <paramref name="exceptionCustomizations"/> defines a custom exception.
    /// </summary>
    [DoesNotReturn, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowNull(
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null,
        string? generalMessage = "Value cannot be null.")
    {
        if (exceptionCustomizations is null)
        {
            throw new ArgumentNullException(paramName: paramName, message: generalMessage);
        }

        throw exceptionCustomizations.Value.Customization.Match(
            message => new ArgumentNullException(paramName: paramName, message: message ?? generalMessage),
            type => (Exception)Activator.CreateInstance(type)!,
            func => func(),
            func => func(paramName));
    }

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/>, unless the <paramref name="exceptionCustomizations"/> defines a custom exception.
    /// </summary>
    [DoesNotReturn, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowOutOfRange<TValue>(
        string paramName,
        TValue actualValue,
        ExceptionCustomizations? exceptionCustomizations = null,
        string? generalMessage = "Specified argument was out of the range of valid values.")
    {
        if (exceptionCustomizations is null)
        {
            throw new ArgumentOutOfRangeException(paramName: paramName, actualValue, message: generalMessage);
        }

        throw exceptionCustomizations.Value.Customization.Match(
            message => new ArgumentOutOfRangeException(paramName: paramName, actualValue, message: message ?? generalMessage),
            type => (Exception)Activator.CreateInstance(type)!,
            func => func(),
            func => func(paramName));
    }

    /// <summary>
    /// Throws an <see cref="ArgumentException"/>, unless the <paramref name="exceptionCustomizations"/> defines a custom exception.
    /// </summary>
    [DoesNotReturn, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Throw(
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null,
        string? generalMessage = null)
    {
        if (exceptionCustomizations is null)
        {
            throw new ArgumentException(message: generalMessage, paramName: paramName);
        }

        throw exceptionCustomizations.Value.Customization.Match(
            message => new ArgumentException(message: message ?? generalMessage, paramName: paramName),
            type => (Exception)Activator.CreateInstance(type)!,
            func => func(),
            func => func(paramName));
    }
}