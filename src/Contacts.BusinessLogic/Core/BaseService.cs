using AutoMapper;
using Contacts.Core.CrossCuttingConcerns.Caching;
using Contacts.DataAccess.Abstract;

namespace Contacts.BusinessLogic.Core
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected ICacheManager CacheManager;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, ICacheManager cacheManager) : this(unitOfWork, mapper)
        {
            CacheManager = cacheManager;
        }
    }
}
