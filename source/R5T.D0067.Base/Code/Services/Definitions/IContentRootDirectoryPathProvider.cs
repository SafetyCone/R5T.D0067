using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0067
{
    [ServiceDefinitionMarker]
    public interface IContentRootDirectoryPathProvider : IServiceDefinition
    {
        Task<string> GetContentRootDirectoryPath();
    }
}
