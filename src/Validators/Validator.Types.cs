namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfType<T>(
        Type type,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations)
    {
        if (type == typeof(T))
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                $"Type shouldn't be {typeof(T)}");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotType<T>(
        Type type,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations)
    {
        if (type != typeof(T))
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                $"Type should be {typeof(T)}");
        }
    }
}