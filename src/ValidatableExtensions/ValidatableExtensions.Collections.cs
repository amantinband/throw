using System.Collections;

namespace Throw;

/// <summary>
/// Extension methods for collections.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the collection is empty.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfEmpty<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCount(
            validatable.Value,
            0,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            "Collection should not be empty.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection is not empty.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotEmpty<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCountNot(
            validatable.Value,
            0,
            validatable.ParamName,
            validatable.ExceptionCustomizations,
            "Collection should be empty.");

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection count does not match the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountNotEquals<TValue>(
        this in Validatable<TValue> validatable,
        int count)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCountNot(validatable.Value, count, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection count matches the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountEquals<TValue>(this in Validatable<TValue> validatable,
        int count)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCount(validatable.Value, count, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection count is greater than the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountGreaterThan<TValue>(
        this in Validatable<TValue> validatable,
        int count)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCountGreaterThan(
            validatable.Value,
            count,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection count is less than the specified <paramref name="count"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfCountLessThan<TValue>(
        this in Validatable<TValue> validatable,
        int count)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfCountLessThan(
            validatable.Value,
            count,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection contains null elements.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfHasNullElements<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull, IEnumerable
    {
        Validator.ThrowIfHasNullElements(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection contains the given <paramref name="element"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfContains<TValue, TElement>(
        this in Validatable<TValue> validatable,
        TElement element)
        where TValue : notnull, IEnumerable<TElement?>
        where TElement : notnull
    {
        Validator.ThrowIfContainsElement(
            validatable.Value,
            element,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the collection does not contain the given <paramref name="element"/>.
    /// Important note: if the collection is a non-evaluated expression, the expression will be evaluated.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotContains<TValue, TElement>(
        this in Validatable<TValue> validatable,
        TElement element)
        where TValue : notnull, IEnumerable<TElement?>
        where TElement : notnull
    {
        Validator.ThrowIfNotContainsElement(
            validatable.Value, element,
            validatable.ParamName,
            validatable.ExceptionCustomizations);

        return ref validatable;
    }
}