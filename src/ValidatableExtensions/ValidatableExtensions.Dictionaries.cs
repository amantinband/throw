using System.Collections;

namespace Throw;

/// <summary>
/// Extension methods for dictionaries.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the dictionary does contain the specified key <paramref name="dictKey"/>
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfContainsKey<TValue,TDictKey>(this in Validatable<TValue> validatable, TDictKey dictKey)
        where TValue : notnull, IDictionary
        where TDictKey : notnull
    {
        Validator.ThrowIfContainsKey<TValue>(validatable.Value, dictKey, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the dictionary does not contain the specified key <paramref name="dictKey"/>
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotContainsKey<TValue>(this in Validatable<TValue> validatable, object dictKey)
        where TValue : notnull, IDictionary
        
    {
        Validator.ThrowIfNotContainsKey<TValue>(validatable.Value, dictKey, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }
}