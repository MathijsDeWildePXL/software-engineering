using System;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE: Code Duplication Problem ===\n");
            DemoBefore();

            Console.WriteLine("\n=== AFTER: Template Method Pattern Solution ===\n");
            DemoAfter();
        }

        static void DemoBefore()
        {
            Console.WriteLine("Processing CSV:");
            var csvProcessor = new Before.CSVDataProcessor();
            csvProcessor.Process();

            Console.WriteLine("Processing JSON:");
            var jsonProcessor = new Before.JSONDataProcessor();
            jsonProcessor.Process();

            Console.WriteLine("Processing XML:");
            var xmlProcessor = new Before.XMLDataProcessor();
            xmlProcessor.Process();

            Console.WriteLine("❌ Problem: Algorithm structure duplicated in each class!");
            Console.WriteLine("❌ What if we need to add a new step? Must modify all classes!");
            Console.WriteLine("❌ No guarantee all processors follow the same sequence!");
        }

        static void DemoAfter()
        {
            Console.WriteLine("Processing CSV:");
            After.DataProcessorBase csvProcessor = new After.CSVDataProcessor();
            csvProcessor.Process();

            Console.WriteLine("Processing JSON:");
            After.DataProcessorBase jsonProcessor = new After.JSONDataProcessor();
            jsonProcessor.Process();

            Console.WriteLine("Processing XML:");
            After.DataProcessorBase xmlProcessor = new After.XMLDataProcessor();
            xmlProcessor.Process();

            Console.WriteLine("✅ Solution: Algorithm defined once, consistent across all processors!");
            Console.WriteLine("✅ Easy to add new processors - just override abstract methods!");
            Console.WriteLine("✅ Shared code (SaveData) in base class - DRY principle!");
            Console.WriteLine("✅ Want to add a new step? Modify base class once!");
        }
    }
}
