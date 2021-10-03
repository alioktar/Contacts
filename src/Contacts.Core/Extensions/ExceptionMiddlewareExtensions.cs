using Contacts.Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Contacts.Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
