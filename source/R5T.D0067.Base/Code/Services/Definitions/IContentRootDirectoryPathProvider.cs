using System;
using System.Threading.Tasks;


namespace R5T.D0067
{
    public interface IContentRootDirectoryPathProvider
    {
        Task<string> GetContentRootDirectoryPath();
    }
}
