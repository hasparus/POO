using Lista_3.DependencyInversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_3.DependencyInversion
{
    interface IDataReader
    {
        string GetData();
    }

    class ConsoleOneLineDataReader : IDataReader
    {
        public string GetData()
        {
            return Console.ReadLine();
        }
    }

    interface IDocumentFormatter
    {
        string FormatDocument(string document);
    }

    public interface IReportPrinter
    {
        void PrintReport(string report);
    }

    class ConsoleReportPrinter : IReportPrinter
    {
        public void PrintReport(string report)
        {
            Console.WriteLine(report);
        }
    }

    class YellerDocumentFormatter : IDocumentFormatter
    {
        public string FormatDocument(string document)
        {
            return document.ToUpper();
        }
    }

    class ReverserDocumentFormatter : IDocumentFormatter
    {
        public string FormatDocument(string document)
        {
            return string.Join("", document.Reverse());
        }
    }

    class CompositeDocumentFormatter : IDocumentFormatter
    {
        readonly IDocumentFormatter[] formatters;
        public CompositeDocumentFormatter(IDocumentFormatter[] formatters)
        {
            this.formatters = formatters;
        }

        public string FormatDocument(string document)
        {
            return formatters.Aggregate(document, 
                (current, formatter) => formatter.FormatDocument(current));
        }
    }

    class ReportComposer
    {
        readonly IDataReader dataReader;
        readonly IDocumentFormatter documentFormatter;
        readonly IReportPrinter reportPrinter;

        public ReportComposer(IDataReader dataReader, 
                              IDocumentFormatter documentFormatter,
                              IReportPrinter reportPrinter)
        {
            this.dataReader = dataReader;
            this.documentFormatter = documentFormatter;
            this.reportPrinter = reportPrinter;
        }

        public string GetData() => dataReader.GetData();
        public string FormatDocument(string document) => 
            documentFormatter.FormatDocument(document);
        public void PrintReport(string report) => 
            reportPrinter.PrintReport(report);

        public void Compose() =>
            PrintReport(FormatDocument(GetData()));
    }

    class ReportComposerExample
    {
        public void Execute()
        {
            var rp = new ReportComposer(
                new ConsoleOneLineDataReader(), 
                new CompositeDocumentFormatter(
                    new IDocumentFormatter[]
                    {
                        new YellerDocumentFormatter(),
                        new ReverserDocumentFormatter(),
                    }),
                new ConsoleReportPrinter());

            rp.Compose();
        }
    }
}
