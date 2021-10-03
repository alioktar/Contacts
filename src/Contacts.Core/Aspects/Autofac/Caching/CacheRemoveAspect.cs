using Castle.DynamicProxy;
using Contacts.Core.CrossCuttingConcerns.Caching;
using Contacts.Core.Interceptors;
using Contacts.Core.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string[] _keys;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(params string[] keys)
        {
            _keys = keys;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            foreach (var key in _keys)
            {
                _cacheManager.RemoveByPattern(key);
            }
        }
    }
}
