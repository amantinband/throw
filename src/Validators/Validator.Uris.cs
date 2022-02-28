namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfSchemeNot(Uri value, string scheme, string paramName, ExceptionCustomizations? exceptionCustomizations = null)
    {
        if (!string.Equals(value.Scheme, scheme, StringComparison.OrdinalIgnoreCase))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Uri scheme should be {scheme}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfScheme(Uri value, string scheme, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (string.Equals(value.Scheme, scheme, StringComparison.OrdinalIgnoreCase))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Uri scheme should not be {scheme}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfAbsolute(Uri value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.IsAbsoluteUri)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "Uri should be relative.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfRelative(Uri value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (!value.IsAbsoluteUri)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "Uri should be absolute.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfPort(Uri value, int port, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.Port == port)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Uri port should not be {port}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfPortNot(Uri value, int port, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.Port != port)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Uri port should be {port}.");
        }
    }
}