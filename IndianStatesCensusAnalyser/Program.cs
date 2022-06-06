// See https://aka.ms/new-console-template for more information
using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using static IndianStatesCensusAnalyser.CensusAnalyser;

Console.WriteLine("Welcome to Indian States Analyzer Problem!");

CensusAnalyser censusAnalyser = new();
string csvPath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
//censusAnalyser.ReadCsvFile();
string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
Dictionary<string, CensusDTO> totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, csvPath, IndianStateCensusHeaders);
Console.WriteLine(totalRecord.Count);