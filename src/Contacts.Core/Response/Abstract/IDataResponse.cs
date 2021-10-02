namespace Contacts.Core.Response.Abstract
{
    public interface IDataResponse<out T> : IResponse
    {
        T Data { get; }
    }
}
