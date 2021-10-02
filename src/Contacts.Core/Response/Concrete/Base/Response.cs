using Contacts.Core.Response.Abstract;

namespace Contacts.Core.Response.Concrete
{
    public class Response : IResponse
    {
        public bool Success { get; }
        public string Message { get; }

        public Response() { }

        public Response(bool success)
        {
            Success = success;
        }

        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
