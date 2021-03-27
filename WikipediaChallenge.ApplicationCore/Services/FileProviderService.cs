using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using WikipediaChallenge.ApplicationCore.Interfaces;
using WikipediaChallenge.Domain.Models;

namespace WikipediaChallenge.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="IFileProviderService"/> implementation, service to get file.
    /// </summary>
    public class FileProviderService : IFileProviderService
    {
        private string TargetFile;
        private string TargetFileNoExt; //file with no extension
        private string SourceUrl;
        private string TargetDirectory;
        /// <summary>
        /// Verify Data temp location.
        /// </summary>
        public void VerifyDataTempLocation()
        {
            if (string.IsNullOrEmpty(TargetDirectory))
                throw new ArgumentNullException("File not found.");
            if (!Directory.Exists(TargetDirectory))
                Directory.CreateDirectory(TargetDirectory);
        }
        /// <summary>
        /// Downloading data.
        /// </summary>     
        public void DownloadData()
        {
            Console.WriteLine(string.Concat("Downloading file ", TargetFile, "..."));
            using WebClient wc = new WebClient();
            wc.DownloadFile(new Uri(SourceUrl), TargetFile);
        }
        /// <summary>
        /// Download data Async.
        /// </summary>
        public void DownloadDataAsync()
        {
            using WebClient wc = new WebClient();
            wc.DownloadProgressChanged += OnDownloadProgressChanged;
            wc.DownloadFileCompleted += OnDownloadFileCompleted;
            wc.DownloadFileAsync(new Uri(SourceUrl), TargetFile); //here private 
        }
        /// <summary>
        /// Change download progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => Console.WriteLine(+e.ProgressPercentage + "%");
       
        /// <summary>
        /// Download file completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
                Console.WriteLine("Oops! An error occurred when download the file");          
            Console.WriteLine("Download complete, press any key to continue...");
        }
        /// <summary>
        /// Set configuration by time.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="folderName"></param>
        public void SetConfigurationByPeriod(DateTime period, string folderName)
        {
            string year = period.Year.ToString();
            string month = period.ToString("MM");
            string formatedDate = period.ToString("yyyyMMdd");
            string formatedTime = period.ToString("HH0000");
            string targetFileName = String.Format(ConfigFile.FileNameTemplate, formatedDate, formatedTime);
            string targetFileNameNoExt = String.Format(ConfigFile.FileNameRawTemplate, formatedDate, formatedTime);
            SourceUrl = String.Format(ConfigFile.PageViewBaseUrlTemplate, year, year, month, formatedDate, formatedTime);
            TargetFile = string.Concat(folderName, "\\", targetFileName);
            TargetFileNoExt = string.Concat(folderName, "\\", targetFileNameNoExt);
            TargetDirectory = folderName;
        }
        /// <summary>
        /// Get data path.
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public string GetDataPath(DateTime period)
        {
            return string.Concat(ConfigFile.TempFolderPath, period.Ticks.ToString());
        }
        /// <summary>
        /// get target file no exist.
        /// </summary>
        /// <returns></returns>
        public string GetTargetFileNoExt()
        {
            return TargetFileNoExt;
        }
    }
}
