using System;

namespace DesignPatterns.SolidDesignPrinciples.InterfaceSegregation
{
    internal class Document
    {
        public Document(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return "Document " + Name;
        }
    }

    internal class FaxMachine : IFaxMachine
    {
        public void Fax(Document document)
        {
            Console.WriteLine("Sending {0} via fax...", document);
        }
    }

    internal class MultiFunctionalPrinter : IMultiFunctionalPrinter
    {
        private readonly IFaxMachine _faxMachine;
        private readonly IPrinter _printer;
        private readonly IScanner _scanner;

        public MultiFunctionalPrinter(IPrinter printer, IScanner scanner, IFaxMachine faxMachine)
        {
            _printer = printer;
            _scanner = scanner;
            _faxMachine = faxMachine;
        }

        public void Fax(Document document)
        {
            _faxMachine.Fax(document);
        }

        public void Print(Document document)
        {
            _printer.Print(document);
        }

        public void Scan(Document document)
        {
            _scanner.Scan(document);
        }
    }

    internal class OldFashionedPrinter : IPrinter
    {
        public void Print(Document document)
        {
            Console.WriteLine("Printing {0}...", document);
        }
    }

    internal class Scanner : IScanner
    {
        public void Scan(Document document)
        {
            Console.WriteLine("Scanning {0}...", document);
        }
    }
}