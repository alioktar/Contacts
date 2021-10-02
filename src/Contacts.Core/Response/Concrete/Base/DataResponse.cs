using Contacts.Core.Response.Abstract;

namespace Contacts.Core.Response.Concrete
{
    public class DataResponse<T> : Response, IDataResponse<T>
    {
        public T Data { get; }

        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }
}
