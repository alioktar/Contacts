namespace Contacts.Core.Response.Concrete
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(true) { }

        public SuccessResponse(string message) : base(true, message) { }
    }
}
