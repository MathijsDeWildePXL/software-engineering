using System;

namespace DataProcessor.After
{
    // SOLUTION: Template Method Pattern - define algorithm skeleton
    
    // Abstract class defines the template method
    public abstract class DataProcessorBase
    {
        // Template method - defines the algorithm structure (sealed to prevent override)
        public void Process()
        {
            ReadData();
            ValidateData();
            TransformData();
            SaveData();
            LogCompletion();
        }

        // Abstract methods - must be implemented by subclasses
        protected abstract void ReadData();
        protected abstract void ValidateData();
        protected abstract void TransformData();

        // Concrete method - shared implementation
        protected void SaveData()
        {
            Console.WriteLine("Saving data to database...");
        }

        // Hook method - optional override
        protected virtual void LogCompletion()
        {
            Console.WriteLine("Processing complete!\n");
        }
    }

    public class CSVDataProcessor : DataProcessorBase
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading data from CSV file...");
        }

        protected override void ValidateData()
        {
            Console.WriteLine("Validating CSV data format...");
        }

        protected override void TransformData()
        {
            Console.WriteLine("Transforming CSV rows to objects...");
        }

        protected override void LogCompletion()
        {
            Console.WriteLine("CSV processing complete!\n");
        }
    }

    public class JSONDataProcessor : DataProcessorBase
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading data from JSON file...");
        }

        protected override void ValidateData()
        {
            Console.WriteLine("Validating JSON structure...");
        }

        protected override void TransformData()
        {
            Console.WriteLine("Parsing JSON to objects...");
        }

        protected override void LogCompletion()
        {
            Console.WriteLine("JSON processing complete!\n");
        }
    }

    public class XMLDataProcessor : DataProcessorBase
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading data from XML file...");
        }

        protected override void ValidateData()
        {
            Console.WriteLine("Validating XML schema...");
        }

        protected override void TransformData()
        {
            Console.WriteLine("Parsing XML to objects...");
        }

        protected override void LogCompletion()
        {
            Console.WriteLine("XML processing complete!\n");
        }
    }

    // Benefits:
    // ✅ Algorithm structure defined once in base class
    // ✅ Subclasses only implement varying steps
    // ✅ Code reuse (SaveData is shared)
    // ✅ Guaranteed consistent algorithm sequence
    // ✅ Easy to add new processors
    // ✅ Easy to modify algorithm (change base class)
}
