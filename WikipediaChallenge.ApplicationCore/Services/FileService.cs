using System;
using System.IO;
using System.IO.Compression;
using WikipediaChallenge.ApplicationCore.Interfaces;

namespace WikipediaChallenge.ApplicationCore.Services
{
    /// <summary>
    /// <see cref="IFileService"/> Inplementation to get file.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Unzip file.
        /// </summary>
        /// <param name="UnzipFile"></param>
        public void Unzip(FileInfo UnzipFile)
        {
            using FileStream originalFileStream = UnzipFile.OpenRead();
            string currentFileName = UnzipFile.FullName;
            Console.WriteLine(string.Concat("Processing file ", currentFileName, "..."));
            string newFileName = currentFileName.Remove(currentFileName.Length - UnzipFile.Extension.Length);
            using FileStream decompressedFileStream = File.Create(newFileName);
            using GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress);
            decompressionStream.CopyTo(decompressedFileStream);
        }
        /// <summary>
        /// Get file extension of file.
        /// </summary>
        /// <returns></returns>
        public string GetFileExtension()
        {
            return "gz";
        }
        /// <summary>
        /// get file extension pattern.
        /// </summary>
        /// <returns></returns>
        
        public string GetFileExtensionPattern()
        {
            return "*.gz";
        }

        
    }
}
