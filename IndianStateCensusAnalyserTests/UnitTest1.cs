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
        string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTests\IndiaCensusTextFile.txt";
        string DelimiterIndianStateCensusDataFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimiterIndiaStateCensusData.csv";
        string IndiaStateCodeCsvFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCode.csv";
        string IndianStateCodeDataWrongFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStateCodeDataWrongFilePath.csv";
        string IndianStateCodeDataWrongFileEntension = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTests\IndianStateCode.txt";
        string DelimeterIndiaStateCode = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimeterIndiaStateCode.csv";


        string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";
        string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string IndiaStateCodeHeaders2 = "srNo,state name,tin,stateCode";



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

        //1.3
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongExtensionFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        //1.4
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }

        //1.5
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }

        //2.1
        [Test]
        public void GivenIndiaStateCodeFile_WhenReaded_ShouldReturnStateCodeCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        //UC 2.2
        [Test]
        public void GivenIndiaStateCodeFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }

        //UC 2.3
        [Test]
        public void GivenIndiaStateCode_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFileEntension, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        //UC 2.4
        [Test]
        public void GivenIndiaStateCode_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                stateRecord = a1.LoadCensusData(DelimeterIndiaStateCode, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }

        //UC 2.5
        [Test]
        public void GivenIndiaStateCode_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}