using System;
using System.Globalization;

namespace FactoryDemo.Documents;

public sealed class PdfDocument : IDocument
{
    private readonly DateTime _creationTime = DateTime.Now;
    private readonly string _fileName;

    public PdfDocument()
    {
        _fileName = $"Document_{_creationTime.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.pdf";
    }

    public void Open()  => Console.WriteLine($"Opening PDF document: {_fileName}\nLoading PDF reader application…");
    public void Save()  => Console.WriteLine($"Saving PDF document: {_fileName}\nDocument saved in .pdf format");
    public void Close() => Console.WriteLine($"Closing PDF document: {_fileName}\nPDF reader application closed");
    public void Print() => Console.WriteLine($"Printing PDF document: {_fileName}\nHigh‑quality print mode enabled…");

    public string GetDocumentType()  => "Portable Document Format";
    public DateTime GetCreationTime() => _creationTime;
}
