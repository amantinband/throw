namespace Throw;

using System.Collections;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfCountNot<TValue>(TValue value, int count, string paramName, ExceptionCustomizations? exceptionCustomizations, string? message = null)
        where TValue : notnull, IEnumerable
    {
        if (GetCollectionCount(value) != count)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, message ?? $"Collection count should be equal to {count}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfCount<TValue>(TValue value, int count, string paramName, ExceptionCustomizations? exceptionCustomizations, string? message = null)
        where TValue : notnull, IEnumerable
    {
        if (GetCollectionCount(value) == count)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, message ?? $"Collection count should not be equal to {count}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfCountGreaterThan<TValue>(TValue value, int count, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        if (GetCollectionCount(value) > count)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection count should not be greater than {count}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfCountLessThan<TValue>(TValue value, int count, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        if (GetCollectionCount(value) < count)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection count should not be less than {count}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfHasNullElements<TValue>(TValue value, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        foreach (var item in value)
        {
            if (item == null)
            {
                ExceptionThrower.Throw(paramName, exceptionCustomizations, "Collection should not have null elements.");
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfAny<TValue, TItem>(TValue value, Func<TItem, bool> predicate, string predicateName, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable<TItem>
    {
        foreach (var item in value)
        {
            if (predicate(item))
            {
                ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should not have any elements matching {predicateName}.");
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int GetCollectionCount<TValue>(TValue value)
        where TValue : notnull, IEnumerable
    {
        static int GetEnumeratedCount(IEnumerable enumerable)
        {
            var count = 0;
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }

        return value switch
        {
            ICollection collection => collection.Count,
            string s => s.Length,
            _ => GetEnumeratedCount(value)
        };
    }
}