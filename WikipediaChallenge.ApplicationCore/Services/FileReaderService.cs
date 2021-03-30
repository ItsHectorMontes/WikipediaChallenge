using System;
using System.IO;
using WikipediaChallenge.ApplicationCore.Interfaces;
using WikipediaChallenge.ApplicationCore.Models;

namespace WikipediaChallenge.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="IFileReaderService"/> implementation. service to read file.
    /// </summary>
    public class FileReaderService : IFileReaderService, IDisposable
    {
        private PageViewCollection _pageViewCollection;
        private string _targetFileNoExt;
        /// <summary>
        /// constructor.
        /// </summary>
        /// <param name="targetFileNoExt"></param>
        public FileReaderService(string targetFileNoExt) => _targetFileNoExt = targetFileNoExt; 
        /// <summary>
        /// get data to collection.
        /// </summary>
        /// <returns> a page view collection.</returns>
        public PageViewCollection GetDataToCollection()
        {
            _pageViewCollection = new PageViewCollection();
            Console.WriteLine(string.Concat("Reading file ", _targetFileNoExt, "..."));
            using (FileStream fs = File.Open(_targetFileNoExt, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                    _pageViewCollection.AddPageView(GetEntry(line));                
            }
            return _pageViewCollection;
        }
        /// <summary>
        /// get entry 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private PageViewEntry GetEntry(string line)
        {
            PageViewEntry entry = new PageViewEntry();            
            string[] data = line.Split(' ');
            entry.DomainCode = data[0];
            entry.PageTitle = data[1];
            entry.ViewCount = Convert.ToUInt32(data[2]);
            return entry;
        } 
        /// <summary>
        /// Dispose pageviewcollection.
        /// </summary>
        public void Dispose() => _pageViewCollection.Dispose();        
    }
}
