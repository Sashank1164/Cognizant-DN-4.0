using System;
using FactoryDemo.Factories;
using FactoryDemo.Documents;

namespace FactoryDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Factory Method Pattern Demo ===\n");

            TestBasicFactoryUsage();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            TestFactoryRegistry();
            Console.WriteLine("\n" + new string('=', 50) + "\n");

            TestDocumentOperations();
        }

        static void TestBasicFactoryUsage()
        {
            Console.WriteLine("1. Basic Factory Usage:");

            var wordDoc = new WordDocumentFactory().ProcessDocument();
            wordDoc.Close();
            Console.WriteLine();

            var pdfDoc = new PdfDocumentFactory().ProcessDocument();
            pdfDoc.Close();
            Console.WriteLine();

            var excelDoc = new ExcelDocumentFactory().ProcessDocument();
            excelDoc.Close();
        }

        static void TestFactoryRegistry()
        {
            Console.WriteLine("2. Factory Registry Usage:");

            Console.WriteLine($"Supported document types: {string.Join(", ", DocumentFactoryRegistry.GetSupportedTypes())}");

            foreach (var type in new[] { "WORD", "PDF", "EXCEL" })
            {
                try
                {
                    var factory = DocumentFactoryRegistry.GetFactory(type);
                    var doc = factory.ProcessDocument(); // ✅ Call ProcessDocument() instead of CreateDocument()
                    doc.Close();
                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void TestDocumentOperations()
        {
            Console.WriteLine("3. Full Document Operations:");

            DocumentFactory[] factories =
            {
                new WordDocumentFactory(),
                new PdfDocumentFactory(),
                new ExcelDocumentFactory()
            };

            foreach (var factory in factories)
            {
                var doc = factory.ProcessDocument(); // ✅ Use public method only
                doc.Print();
                doc.Close();
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
