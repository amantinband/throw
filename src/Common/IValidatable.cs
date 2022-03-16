namespace Throw;

/// <summary>
/// asdf.
/// </summary>
/// <typeparam name="T">asdf.</typeparam>
public interface IValidatable<out T>
{
    /// <summary>
    /// asdf.
    /// </summary>
    /// <value></value>
    T Value { get; }

    /// <summary>
    /// asdf.
    /// </summary>
    /// <value></value>
    string ParamName { get; }

    /// <summary>
    /// asdf.
    /// </summary>
    ExceptionCustomizations? ExceptionCustomizations { get; }
}