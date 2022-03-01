using System.Collections;

namespace Throw;

/// <summary>
/// Extension methods for collection properties.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the collection returned from the given <paramref name="func"/> is empty.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEmpty<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCount(func(validatable.Value), 0, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, "Collection should not be empty.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection returned from the given <paramref name="func"/> is not empty.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEmpty<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCountNot(func(validatable.Value), 0, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations, "Collection should be empty.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the size of the collection returned from the given <paramref name="func"/> does not match the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountNotEquals<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, int count, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCountNot(func(validatable.Value), count, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the size of the collection returned from the given <paramref name="func"/> does matches the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountEquals<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, int count, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCount(func(validatable.Value), count, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the size of the collection returned from the given <paramref name="func"/> is greater than the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountGreaterThan<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, int count, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCountGreaterThan(func(validatable.Value), count, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the size of the collection returned from the given <paramref name="func"/> is less than the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountLessThan<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, int count, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfCountLessThan(func(validatable.Value), count, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the size of the collection returned from the given <paramref name="func"/> contains null elements.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfHasNullElements<TValue, TCollectionType>(this in Validatable<TValue> validatable, Func<TValue, TCollectionType> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
        where TCollectionType : IEnumerable
    {
        Validator.ThrowIfHasNullElements(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }
}