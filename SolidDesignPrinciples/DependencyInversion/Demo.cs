using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.SolidDesignPrinciples.DependencyInversion
{
    class Demo
    {
        public static void Run()
        {
            var parent = new Person { Name = "Adam" };
            var child1 = new Person { Name = "Abel" };
            var child2 = new Person { Name = "Cain" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            // consumer has no direct access to the data in relationships
            // but is aware that this data is accessible via interface
            var children = relationships.FindAllChildrenOf("Adam");
            foreach(var child in children)
            {
                Console.WriteLine($"Adam has a child named {child.Name}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
    }

    enum Relationship { Parent, Child, Sibling }

    // introduce and abstraction layer using Interface
    interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low-level
    class Relationships : IRelationshipBrowser
    {
        // this should not be publicly available in high-level
        // classes so that implementation may be modified
        // without affecting those classes dependent on it
        private List<(Person, Relationship, Person)> _relations
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        // accessing the data now depends on the interface implementation
        public IEnumerable<Person> FindAllChildrenOf(string name) =>
            _relations
                .Where(x => x.Item1.Name == name &&
                            x.Item2 == Relationship.Parent)
                .Select(r => r.Item3);
    }
}
