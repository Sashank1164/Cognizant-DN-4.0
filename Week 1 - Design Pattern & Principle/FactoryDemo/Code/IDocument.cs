using System;

namespace FactoryDemo.Documents;

/// <summary>
/// Abstraction for all document types
/// </summary>
public interface IDocument
{
    void Open();
    void Save();
    void Close();
    void Print();

    string GetDocumentType();
    DateTime GetCreationTime();
}
