using Contacts.BusinessLogic.Core;
using Contacts.DTOs.Concrete;

namespace Contacts.BusinessLogic.Services.Abstract
{
    public interface IContactService : IBaseService<ContactDto>
    {
    }
}
