using WikipediaChallenge.ApplicationCore.Models;

namespace WikipediaChallenge.ApplicationCore.Interfaces
{/// <summary>
/// File Reader interface.
/// </summary>
    public interface IFileReaderService
    {
        PageViewCollection GetDataToCollection();
    }
}
