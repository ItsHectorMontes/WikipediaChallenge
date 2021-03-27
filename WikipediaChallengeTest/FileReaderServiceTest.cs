using System.Collections.Generic;
using WikipediaChallenge.ApplicationCore.Services;
using Xunit;

namespace WikipediaChallengeTest
{
    public class FileReaderServiceTest
    {
        
        [Fact]
        public void GetDataCollectionTest()
        {
            //arrange
            string targetFileNoExt = "C:\\TempWiki\\637522180699923889\\pageviews-20210324-210000";
            //act
            var _fileReaderService = new FileReaderService(targetFileNoExt);                    
            //asert
            Assert.True(true);
        }
        
    }
}
