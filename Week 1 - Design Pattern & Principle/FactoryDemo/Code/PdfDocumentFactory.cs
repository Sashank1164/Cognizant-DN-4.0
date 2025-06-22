using System;
using FactoryDemo.Documents;

namespace FactoryDemo.Factories;

public sealed class PdfDocumentFactory : DocumentFactory
{
    protected override IDocument CreateDocument()
    {
        Console.WriteLine("PdfDocumentFactory: Creating new PDF document…");
        return new PdfDocument();
    }
}
