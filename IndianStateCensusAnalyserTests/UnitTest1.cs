using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserTests
{
    public class Tests
    {
        string csvPath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
        string IndianStateCensusDataWrongFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensus.csv";

        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        //1.1
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //1.2
        
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
    }
}