using System;
using System.Configuration;


namespace WikipediaChallenge.ApplicationCore.Models
{
    /// <summary>
    /// config file xml.
    /// </summary>
    public class ConfigFile
    {
        public static string TempFolderPath = ConfigurationManager.AppSettings["TempFolderPath"];
        public static string PageViewBaseUrlTemplate = ConfigurationManager.AppSettings["PageViewBaseUrlTemplate"];
        public static string FileNameTemplate = ConfigurationManager.AppSettings["FileNameTemplate"];
        public static string FileNameRawTemplate = ConfigurationManager.AppSettings["FileNameRawTemplate"];
        public static string TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public const int OperatorBackHours = -1;
    }
}
