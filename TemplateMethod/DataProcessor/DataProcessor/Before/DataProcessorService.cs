using System;

namespace DataProcessor.Before
{
    // PROBLEM: Code duplication - same algorithm structure repeated
    
    public class CSVDataProcessor
    {
        public void Process()
        {
            // Step 1: Read data
            Console.WriteLine("Reading data from CSV file...");
            
            // Step 2: Validate data
            Console.WriteLine("Validating CSV data format...");
            
            // Step 3: Transform data
            Console.WriteLine("Transforming CSV rows to objects...");
            
            // Step 4: Save data
            Console.WriteLine("Saving data to database...");
            
            Console.WriteLine("CSV processing complete!\n");
        }
    }

    public class JSONDataProcessor
    {
        public void Process()
        {
            // Step 1: Read data (different implementation)
            Console.WriteLine("Reading data from JSON file...");
            
            // Step 2: Validate data (different implementation)
            Console.WriteLine("Validating JSON structure...");
            
            // Step 3: Transform data (different implementation)
            Console.WriteLine("Parsing JSON to objects...");
            
            // Step 4: Save data (same as CSV)
            Console.WriteLine("Saving data to database...");
            
            Console.WriteLine("JSON processing complete!\n");
        }
    }

    public class XMLDataProcessor
    {
        public void Process()
        {
            // Step 1: Read data (different implementation)
            Console.WriteLine("Reading data from XML file...");
            
            // Step 2: Validate data (different implementation)
            Console.WriteLine("Validating XML schema...");
            
            // Step 3: Transform data (different implementation)
            Console.WriteLine("Parsing XML to objects...");
            
            // Step 4: Save data (same as others)
            Console.WriteLine("Saving data to database...");
            
            Console.WriteLine("XML processing complete!\n");
        }
    }

    // Problems:
    // ❌ Algorithm structure duplicated in each class
    // ❌ If we need to add a new step, must modify all classes
    // ❌ No guarantee that all processors follow same sequence
    // ❌ Code maintenance nightmare
}
