using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Middlewares
{
    public static class APIKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKey(this IApplicationBuilder builder, string apiKey)
        {
            return builder.UseMiddleware<APIKeyMiddleware>(apiKey);
        }
    }
}
