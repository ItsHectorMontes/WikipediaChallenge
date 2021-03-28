using System;
using System.IO;
using WikipediaChallenge.ApplicationCore.Interfaces;
using WikipediaChallenge.ApplicationCore.Models;


namespace WikipediaChallenge.Infrastructure.Repository
{/// <summary>
/// get all data to then process it.
/// </summary>
    public class DataRaw
    {
        private IFileService _fileService;
        private IFileProviderService _fileProviderService;
        private int LastNumberHours;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fileService"></param>
        /// <param name="fileProviderService"></param>
        /// <param name="lastNumberHours"></param>
        public DataRaw(IFileService fileService, IFileProviderService fileProviderService, int lastNumberHours)
        {
            _fileProviderService = fileProviderService;
            _fileService = fileService;
            LastNumberHours = lastNumberHours;
        }
        /// <summary>
        /// Download Data using parameters.
        /// </summary>
        /// <param name="startPeriod"></param>
        /// <param name="endPeriod"></param>
        /// <param name="directoryName"></param>
        public void DownloadAllPeriodsData(DateTime startPeriod, DateTime endPeriod, string directoryName)
        {
            do
            {
                DownloadByPeriod(startPeriod, directoryName);
                startPeriod = startPeriod.AddHours(ConfigFile.OperatorBackHours);
            }
            while (startPeriod.CompareTo(endPeriod) != 0);
            Console.WriteLine("All files from wikimedia has been downloaded.");
        }
        /// <summary>
        /// Download by period using parameters.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="directoryName"></param>
        private void DownloadByPeriod(DateTime period, string directoryName)
        {
            _fileProviderService.SetConfigurationByPeriod(period, directoryName);
            _fileProviderService.VerifyDataTempLocation();
            _fileProviderService.DownloadData();
        }
        /// <summary>
        /// Unzip data.
        /// </summary>
        /// <param name="folderPath"></param>
        public void DecompressData(string folderPath)
        {
            DirectoryInfo directorySelected = new DirectoryInfo(folderPath);
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles(_fileService.GetFileExtensionPattern()))            
                _fileService.Unzip(fileToDecompress); 
            Console.WriteLine("All files has been decompress.");
        }

    }
}