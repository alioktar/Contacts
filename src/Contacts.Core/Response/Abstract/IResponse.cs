namespace Contacts.Core.Response.Abstract
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
