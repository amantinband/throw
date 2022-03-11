namespace Throw;

using System.Collections;
using System.Linq.Expressions;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContainsElement<TValue>(TValue value, Expression<Func<TValue, bool>> predicate, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        foreach (var item in value)
        {
            if (item)
            {
                ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should not contain element {element}.");
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContainsSingleElement<TValue>(TValue value, dynamic element, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        var count = 0;
        foreach (var item in value)
        {
            if (item == element)
            {
                count++;
                if (count > 1) break;
            }
        }
        if (count == 1)  ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should not contain a single element having value of {element}.");
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContainsNoSingleElement<TValue>(TValue value, dynamic element, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        var count = 0;
        foreach (var item in value)
        {
            if (item == element)
            {
                count++;
                if (count > 1) break;
            }
        }
        if (count > 1) ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should not contain multiple occurences of element having value of {element}.");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContainsNone<TValue>(TValue value, dynamic element, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        var count = 0;
        foreach (var item in value)
        {
            if (item == element)
            {
                count++;
                if (count > 0) break;
            }
        }
        if (count > 0) ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should contain at least one occurences of element having value of {element}.");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfAll<TValue>(TValue value, dynamic element, string paramName, ExceptionCustomizations? exceptionCustomizations)
        where TValue : notnull, IEnumerable
    {
        bool notAll = false;
        foreach (var item in value)
        {
            if (item != element)
            {
                notAll = true;
                if (notAll) break;
            }
        }
        if (!notAll) ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Collection should contain at least one occurences of an element not of the same value as the element {element}.");
    }

}