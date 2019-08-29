using System;

namespace DesignPatterns.SolidDesignPrinciples.OpenClosed
{
    public class Demo
    {
        public static void Run()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};

            Console.WriteLine("Green products (old):");
            var pf = new ProductFilter();
            foreach (var product in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine("  - {0} is green", product.Name);
            }

            Console.WriteLine("Green products (new):");
            var bf = new BetterFilter();
            foreach (var product in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine("  - {0} is green", product.Name);
            }

            Console.WriteLine("Large blue items");
            var largeBlueItems = new AndSpecification(new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large));
            foreach (var product in bf.Filter(products, largeBlueItems))
            {
                Console.WriteLine("  - {0} is large and blue", product.Name);
            }
        }
    }
}