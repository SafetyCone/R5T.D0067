using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0062;
using R5T.D0065;
using R5T.D0066;


namespace R5T.D0067
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AspNetCoreContentRootDirectoryPathProvider"/> implementation of <see cref="IContentRootDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAspNetCoreContentRootDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<ICurrentDirectoryPathProvider> currentDirectoryPathProviderAction,
            IServiceAction<IEnvironmentNameProvider> environmentNameProviderAction,
            IServiceAction<IExecutableDirectoryPathProvider> executableDirectoryPathProviderAction)
        {
            services
                .AddSingleton<IContentRootDirectoryPathProvider, AspNetCoreContentRootDirectoryPathProvider>()
                .Run(currentDirectoryPathProviderAction)
                .Run(environmentNameProviderAction)
                .Run(executableDirectoryPathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AspNetCoreContentRootDirectoryPathProvider"/> implementation of <see cref="IContentRootDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IContentRootDirectoryPathProvider> AddAspNetCoreContentRootDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<ICurrentDirectoryPathProvider> currentDirectoryPathProviderAction,
            IServiceAction<IEnvironmentNameProvider> environmentNameProviderAction,
            IServiceAction<IExecutableDirectoryPathProvider> executableDirectoryPathProviderAction)
        {
            var serviceAction = ServiceAction.New<IContentRootDirectoryPathProvider>(() => services.AddAspNetCoreContentRootDirectoryPathProvider(
                currentDirectoryPathProviderAction,
                environmentNameProviderAction,
                executableDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
