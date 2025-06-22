using System;
using System.Collections.Generic;

namespace FactoryDemo.Factories;

public static class DocumentFactoryRegistry
{
    private static readonly Dictionary<string, DocumentFactory> _factories = new(StringComparer.OrdinalIgnoreCase)
    {
        ["WORD"]  = new WordDocumentFactory(),
        ["PDF"]   = new PdfDocumentFactory(),
        ["EXCEL"] = new ExcelDocumentFactory()
    };

    public static DocumentFactory GetFactory(string documentType) =>
        _factories.TryGetValue(documentType, out var factory)
            ? factory
            : throw new ArgumentException($"Unknown document type: {documentType}", nameof(documentType));

    public static string[] GetSupportedTypes() => _factories.Keys.ToArray();
}
