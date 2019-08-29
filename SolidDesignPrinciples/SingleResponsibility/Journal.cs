using System;
using System.Collections.Generic;

namespace DesignPatterns.SolidDesignPrinciples.SingleResponsibility
{
    public class Journal
    {
        private static int _count;
        private readonly List<string> _entries = new List<string>();

        public int AddEntry(string text)
        {
            _entries.Add(string.Format("{0}: {1}", ++_count, text));
            return _count; // memento
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }
}