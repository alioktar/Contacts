namespace Contacts.Core.Response.Concrete
{
    public class ErrorResponse : Response
    {
        public ErrorResponse() : base(false) { }

        public ErrorResponse(string message) : base(false, message) { }
    }
}
