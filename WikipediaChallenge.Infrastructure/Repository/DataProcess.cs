using System;
using WikipediaChallenge.ApplicationCore.Models;
using WikipediaChallenge.ApplicationCore.Services;
using WikipediaChallenge.Infrastructure.Models;

namespace WikipediaChallenge.Infrastructure.Repository
{/// <summary>
/// DataProcess
/// </summary>
    public class DataProcess
    {
        private FileService _fileService;
        private DataDomain _dataDomain;
        private FileProviderService _fileProviderService;
        private int HoursNumber;
        private DateTime StartPeriod;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="hoursNumber"></param>
        /// <param name="startPeriod"></param>
        public DataProcess(int hoursNumber, DateTime startPeriod)
        {
            _fileService = new FileService();
            _fileProviderService = new FileProviderService();
            _dataDomain = new DataDomain();
            HoursNumber = hoursNumber;            
            StartPeriod = startPeriod.AddHours(-1);
        }
        /// <summary>
        /// Run Main process, getting 2 repports.
        /// </summary>
        public void RunMainProcess()
        {
            LanguageDomainCountReport firstReport = new LanguageDomainCountReport();
            LanguagePageCountReport secondReport = new LanguagePageCountReport();
            string targetFile;
            DateTime startPeriod = StartPeriod;
            DateTime endPeriod = StartPeriod.AddHours(HoursNumber * ConfigFile.OperatorBackHours);
            string directoryPath = _fileProviderService.GetDataPath(startPeriod);
            DataRaw dataRaw = new DataRaw(_fileService, _fileProviderService, HoursNumber);
            dataRaw.DownloadAllPeriodsData(startPeriod, endPeriod, directoryPath);
            dataRaw.DecompressData(directoryPath);
            DataCollection processData = new DataCollection(_dataDomain);
            startPeriod = StartPeriod;            
            do
            {
                _fileProviderService.SetConfigurationByPeriod(startPeriod, directoryPath);
                targetFile = _fileProviderService.GetTargetFileNoExt();                
                using (FileReaderService frs = new FileReaderService(targetFile))
                {
                    Console.WriteLine(string.Concat("Data is Processing ", targetFile, "..."));
                    PageViewCollection periodCollection = frs.GetDataToCollection();
                    Console.WriteLine("\tProcessing language and domain data for period " + startPeriod.ToShortDateString());
                    LanguageDomainCount languageDomain = processData.GetLanguageAndDomainCount(periodCollection);
                    languageDomain.Period = startPeriod;
                    firstReport.AddLanguageDomain(languageDomain);                    
                    LanguagePageCount languagePage = processData.GetLanguagePageCount(periodCollection);
                    Console.WriteLine("\tProcessing language page data for period " + startPeriod.ToShortDateString());
                    languagePage.Period = startPeriod;
                    secondReport.AddLanguagePage(languagePage);
                }
                startPeriod = startPeriod.AddHours(ConfigFile.OperatorBackHours);
            }
            while (startPeriod.CompareTo(endPeriod) != 0);            
            Console.Clear();
            DataToConsole.DisplayLanguageDomainCount(firstReport);
            DataToConsole.DisplayLanguagePageMaxCount(secondReport);
        }
    }
   
}
