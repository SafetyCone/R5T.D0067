using System;
using System.Threading.Tasks;

using R5T.D0062;
using R5T.D0065;
using R5T.D0066;
using R5T.T0064;


namespace R5T.D0067
{
    /// <summary>
    /// Provides the current directory path in the development environment (which Visual Studio sets to the project directory by default), and the executable directory path otherwise.
    /// </summary>
    [ServiceImplementationMarker]
    public class AspNetCoreContentRootDirectoryPathProvider : IContentRootDirectoryPathProvider, IServiceImplementation
    {
        private ICurrentDirectoryPathProvider CurrentDirectoryPathProvider { get; }
        private IEnvironmentNameProvider EnvironmentNameProvider { get; }
        private IExecutableDirectoryPathProvider ExecutableDirectoryPathProvider { get; }


        public AspNetCoreContentRootDirectoryPathProvider(
            ICurrentDirectoryPathProvider currentDirectoryPathProvider,
            IEnvironmentNameProvider environmentNameProvider,
            IExecutableDirectoryPathProvider executableDirectoryPathProvider)
        {
            this.CurrentDirectoryPathProvider = currentDirectoryPathProvider;
            this.EnvironmentNameProvider = environmentNameProvider;
            this.ExecutableDirectoryPathProvider = executableDirectoryPathProvider;
        }

        public async Task<string> GetContentRootDirectoryPath()
        {
            if(await this.EnvironmentNameProvider.IsDevelopment())
            {
                var currentDirectoryPath = await this.CurrentDirectoryPathProvider.GetCurrentDirectoryPath();
                return currentDirectoryPath;
            }
            else
            {
                var executableDirectoryPath = await this.ExecutableDirectoryPathProvider.GetExecutableDirectoryPath();
                return executableDirectoryPath;
            }
        }
    }
}
