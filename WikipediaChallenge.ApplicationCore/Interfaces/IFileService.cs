using System.IO;

namespace WikipediaChallenge.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface to file service.
    /// </summary>
    public interface IFileService
    {
        string GetFileExtensionPattern();
        string GetFileExtension();
        void Unzip(FileInfo UnzipFile);
        
    }
}
