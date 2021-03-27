using System;
using WikipediaChallenge.ApplicationCore.Services;
using Xunit;

namespace WikipediaChallengeTest
{
    public class FIleServiceTest
    {
        FileService _fileService = new FileService();

        [Fact]
        public void GetFileExtensionTest()
        {
            string value = _fileService.GetFileExtension();
            Assert.Equal("gz", value);
        }
    }
}
