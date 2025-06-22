using System;
using System.Globalization;

namespace FactoryDemo.Documents;

public sealed class WordDocument : IDocument
{
    private readonly DateTime _creationTime = DateTime.Now;
    private readonly string _fileName;

    public WordDocument()
    {
        _fileName = $"Document_{_creationTime.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.docx";
    }

    public void Open()  => Console.WriteLine($"Opening Word document: {_fileName}\nLoading Microsoft Word application…");
    public void Save()  => Console.WriteLine($"Saving Word document: {_fileName}\nDocument saved in .docx format");
    public void Close() => Console.WriteLine($"Closing Word document: {_fileName}\nMicrosoft Word application closed");
    public void Print() => Console.WriteLine($"Printing Word document: {_fileName}\nSending to default printer…");

    public string GetDocumentType()  => "Microsoft Word Document";
    public DateTime GetCreationTime() => _creationTime;
}
