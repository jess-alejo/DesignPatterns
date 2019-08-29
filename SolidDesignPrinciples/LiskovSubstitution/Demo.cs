using System;

namespace DesignPatterns.SolidDesignPrinciples.LiskovSubstitution
{
    internal class Demo
    {
        public static void Run()
        {
            var rc = new Rectangle(2, 3);
            Console.WriteLine("A rectangle of {0} has area {1}", rc, Area(rc));

            Rectangle sq = new Square();
            sq.Width = 3;
            Console.WriteLine("A square of {0} has area {1}", sq, Area(sq));
        }

        private static int Area(Rectangle r) => r.Width*r.Height;
    }
}