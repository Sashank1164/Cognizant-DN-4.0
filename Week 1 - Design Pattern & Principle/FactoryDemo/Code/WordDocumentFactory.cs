using System;
using FactoryDemo.Documents;

namespace FactoryDemo.Factories
{
    public class WordDocumentFactory : DocumentFactory
    {
        protected override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}
