using System;
using System.Globalization;

namespace FactoryDemo.Documents;

public sealed class ExcelDocument : IDocument
{
    private readonly DateTime _creationTime = DateTime.Now;
    private readonly string _fileName;

    public ExcelDocument()
    {
        _fileName = $"Spreadsheet_{_creationTime.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.xlsx";
    }

    public void Open()  => Console.WriteLine($"Opening Excel document: {_fileName}\nLoading Microsoft Excel application…");
    public void Save()  => Console.WriteLine($"Saving Excel document: {_fileName}\nWorkbook saved in .xlsx format");
    public void Close() => Console.WriteLine($"Closing Excel document: {_fileName}\nMicrosoft Excel application closed");
    public void Print() => Console.WriteLine($"Printing Excel document: {_fileName}\nPrinting all worksheets…");

    public string GetDocumentType()  => "Microsoft Excel Spreadsheet";
    public DateTime GetCreationTime() => _creationTime;
}
