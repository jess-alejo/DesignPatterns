using System;
using System.Diagnostics;

namespace DesignPatterns.SolidDesignPrinciples.SingleResponsibility
{
    // Every module or class should have responsibility over a
    // single part of the functionality provided by the software, and that
    // responsibility should be entirely encapsulated by the class.

    // If a class or module has more than one responsiblities, it should
    // be decoupled and responsibilities should execute independently.
    public class Demo
    {
        public static void Run()
        {
            var j = new Journal();
            j.AddEntry("I ride with my love.");
            j.AddEntry("I'm working on my next novel.");

            Console.WriteLine(j);

            var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = System.IO.Path.Combine(dir, "journal.txt");

            var p = new Persistence();
            p.SaveToFile(j, fileName);

            Process.Start(fileName);
        }
    }
}