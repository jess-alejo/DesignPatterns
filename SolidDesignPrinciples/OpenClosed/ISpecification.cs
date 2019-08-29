namespace DesignPatterns.SolidDesignPrinciples.OpenClosed
{
    internal interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    internal class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Color == _color;
        }
    }

    internal class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return product.Size == _size;
        }
    }

    // combinator
    internal class AndSpecification : ISpecification<Product>
    {
        private readonly ColorSpecification _colorSpecification;
        private readonly SizeSpecification _sizeSpecification;

        public AndSpecification(ColorSpecification colorSpecification, SizeSpecification sizeSpecification)
        {
            _colorSpecification = colorSpecification;
            _sizeSpecification = sizeSpecification;
        }

        public bool IsSatisfied(Product t)
        {
            return _colorSpecification.IsSatisfied(t) && _sizeSpecification.IsSatisfied(t);
        }
    }
}