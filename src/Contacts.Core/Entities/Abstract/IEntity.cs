using System;

namespace Contacts.Core.Entities.Abstract
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
