using System;

namespace DesignPatterns.SolidDesignPrinciples.InterfaceSegregation
{
    internal class Demo
    {
        public static void Run()
        {
            Console.WriteLine("Class inheriting in single interface:");
            var document = new Document("My Bio");
            var oldPrinter = new OldFashionedPrinter();
            oldPrinter.Print(document);
            Console.WriteLine(new string('=', 25));

            Console.WriteLine("Class implementing multiple interfaces:");
            var multiPurposePrinter = new MultiFunctionalPrinter(new OldFashionedPrinter(), new Scanner(),
                new FaxMachine());

            multiPurposePrinter.Print(document);
            multiPurposePrinter.Scan(document);
            multiPurposePrinter.Fax(document);
        }
    }
}