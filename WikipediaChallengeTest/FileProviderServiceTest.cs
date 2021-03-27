using Xunit;
using WikipediaChallenge.ApplicationCore.Services;
using System;

namespace WikipediaChallengeTest
{
    public class FileProviderServiceTest
    {
        FileProviderService _fileProviderService = new FileProviderService();

        [Fact]
        public void VerifyDataTempLocationTest()
        {
            //arrange
            _fileProviderService.GetTargetFileNoExt();
            //assert
            Assert.True(true);
        }
        [Fact]
        public void GetDataPathTest()
        {
            //arrange
            var date = new DateTime(2000, 4, 16);            
            //act 
            _fileProviderService.GetDataPath(date);
            //assert
            Assert.True(true);


        }
    }


}
