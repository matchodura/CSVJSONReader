using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVJSONReader
{
    class Program
    {
        static void Main(string[] args)
        {
      
            var allFileLines = File.ReadAllLines(@"C:\test.csv");
            string fileName = Path.GetFileName(@"C:\test.csv");
        
            List<string> listofItems = new List<string>();
            List<int> countofItems = new List<int>();

            int totalItemsCount = 0;
            int requestNumber = 0;

            //name of json's property i.e cars
            string itemToLookFor = "cars";

            foreach (string line in allFileLines)
            {
                if (line.Contains(itemToLookFor))
                {               
                    //looking for start and end of json's array
                    int start = line.IndexOf("[") + 1;
                    int end = line.IndexOf("]", start);
                    string result = line.Substring(start, end - start);
               

                    //getting number of elements between comma - total items in array
                    var itemsInRequest = result.Split(',').Count();                   
                    countofItems.Add(itemsInRequest);

                    totalItemsCount += itemsInRequest;
                    requestNumber += 1;

                    Console.WriteLine($"Request number: {requestNumber}, items count:{itemsInRequest}");
                }

              
            }


            Console.WriteLine($"Items in file {fileName}: {totalItemsCount}");
        }
    }
}
