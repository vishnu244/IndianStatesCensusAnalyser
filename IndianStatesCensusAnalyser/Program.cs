// See https://aka.ms/new-console-template for more information
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using static IndianStatesCensusAnalyser.CensusAnalyser;

Console.WriteLine("Welcome to Indian States Analyzer Problem!");

CensusAnalyser censusAnalyser = new();
string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTests\IndiaCensusTextFile.txt";
string IndianStateCensusDataWrongFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStateCensusData.csv";
string csvPath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
string DelimiterIndianStateCensusDataFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimiterIndiaStateCensusData.csv";
string IndiaStateCodeCsvFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCode.csv";
string IndianStateCodeDataWrongFilePath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndianStateCodeDataWrongFilePath.csv";
string IndianStateCodeDataWrongFileEntension = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStateCensusAnalyserTests\IndianStateCode.txt";
string DelimeterIndiaStateCode = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimeterIndiaStateCode.csv";


//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
string IndianStateCensusHeaders2 = "States,population,areaInSqKm,densityPerSqKm";
string IndiaStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
string IndiaStateCodeHeaders2 = "srNo,state name,tin,stateCode";



while (true)
{
    Console.WriteLine("Please choose the option: \n1)UC1 - Check the number of records in CSV file\n2)UC1.2 - Given wrong file Path\n3)UC1.3 - Giving wrong text file as Input\n4)UC1.4-Throw exception if Delimeter is Wrong\n5)UC1.5-Throw exception " +
        "if Header is Wrong\n6)UC2 Load India State code (Count Rows)\n7)UC2.2 Given wrong file Path(for Indian State code)\n8)UC2.3Throw exception if Extension is Wrong(for Indian State code)\n9)UC2.4-Throw exception if Delimeter is Wrong(for Indian State code)\n10)UC 2.5 Throw exception if header is Wrong(for Indian State code)");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
            Console.WriteLine(totalRecord.Count);
            break;
        case 2:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 3:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCensusDataWrongExtensionFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 4:
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                totalRecord = a1.LoadCensusData(DelimiterIndianStateCensusDataFilePath, IndianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 5:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 6:
            Dictionary<string, CensusDTO> stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders);
            Console.WriteLine(stateRecord.Count);
            break;
        case 7:
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFilePath, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 8:
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeDataWrongFileEntension, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 9:
            try
            {
                IndianCensusAdapter a1 = new IndianCensusAdapter();
                stateRecord = a1.LoadCensusData(DelimeterIndiaStateCode, IndiaStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 10:
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndiaStateCodeCsvFilePath, IndiaStateCodeHeaders2);
            }
            catch (CensusAnalyserException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        default:
            Console.WriteLine("Please choose Valid option!");
            break;
    }
}