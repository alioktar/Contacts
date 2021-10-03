using System;

namespace Contacts.BusinessLogic.Core.Exceptions
{
    class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message) { }
    }
}
