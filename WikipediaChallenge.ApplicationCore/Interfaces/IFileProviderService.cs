using System;


namespace WikipediaChallenge.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface File provider.
    /// </summary>
    public interface IFileProviderService
    {
        void VerifyDataTempLocation();
        void SetConfigurationByPeriod(DateTime period, string folderName);
        void DownloadData();        
        void DownloadDataAsync();
    }
}
