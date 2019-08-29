namespace DesignPatterns.SolidDesignPrinciples.InterfaceSegregation
{
    internal interface IFaxMachine
    {
        void Fax(Document document);
    }

    internal interface IMultiFunctionalPrinter : IPrinter, IScanner, IFaxMachine
    {
    }

    internal interface IPrinter
    {
        void Print(Document document);
    }

    internal interface IScanner
    {
        void Scan(Document document);
    }
}