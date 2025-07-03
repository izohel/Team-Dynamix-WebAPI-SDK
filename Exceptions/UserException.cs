namespace TeamDynamix.Api.Exceptions;

/// <summary>
/// 
/// </summary>
public class UserException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    public UserException()
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public UserException(string? message) : base(message)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public UserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}