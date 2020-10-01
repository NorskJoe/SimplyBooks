using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SimplyBooks.Services.Extensions
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Register all implementations of a given interface and assembly
        /// </summary>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="provider"></param>
        /// <param name="transformFunc"></param>
        /// <returns></returns>
        public static TValue GetOptionsValue<TObj, TValue>(this IServiceProvider provider, Func<TObj, TValue> transformFunc)
            where TObj : class, new()
        {
            return transformFunc(provider.GetService<IOptions<TObj>>().Value);
        }
    }
}
