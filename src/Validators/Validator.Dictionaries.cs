namespace Throw;

using System.Collections;

internal static partial class Validator
{
    /// <summary>
    /// Throws an exception if the dictionary does not contain the specified key <paramref name="dictKey"/>
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContainsKey<TValue>(TValue value, object dictKey, string paramName, ExceptionCustomizations? exceptionCustomizations, string? message = null)
        where TValue : notnull, IDictionary
    {
        if (value.Contains(dictKey))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, message ?? $"Dictionary should not contain key {dictKey}.");
        }
    }
    
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotContainsKey<TValue>(TValue value, Object dictKey, string paramName, ExceptionCustomizations? exceptionCustomizations, string? message = null)
        where TValue : notnull, IDictionary
    {
        if (! value.Contains(dictKey))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, message ?? $"Dictionary should contain key {dictKey}.");
        }
    }
    

}

