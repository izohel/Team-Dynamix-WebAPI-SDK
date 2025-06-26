namespace Itsm.Tdx.WebApi.Exceptions;

[Serializable]
internal class UserException : Exception
{
    public UserException()
    {
    }

    public UserException(string? message) : base(message)
    {
    }

    public UserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}