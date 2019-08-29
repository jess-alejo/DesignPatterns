namespace DesignPatterns.SolidDesignPrinciples.LiskovSubstitution
{
    // The 'virtual' keyword is used to modify a method, property, indexer, or event declaration
    // and allow for it to be overridden in a derived class.
    internal class Rectangle
    {
        private int _height;
        private int _width;

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public virtual int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public virtual int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}", Width, Height);
        }
    }

    // The 'override' modifier is required to extend or modify the abstract or virtual
    // implementation of an inherited method, property, indexer, or event.
    internal class Square : Rectangle
    {
        public override int Height
        {
            set { base.Height = base.Width = value; }
        }

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
    }
}