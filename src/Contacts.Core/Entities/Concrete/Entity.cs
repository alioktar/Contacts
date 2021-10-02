using Contacts.Core.Entities.Abstract;
using System;

namespace Contacts.Core.Entities.Concrete
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
