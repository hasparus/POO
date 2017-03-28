using System;

namespace Lista_3.Liskov
{
    // Jak nie trzymam żadnej informacji o kątach to kwadrat i prostokąt nie mają nic wspólnego.
    // Zostają po prostu krotką jedno i dwuelementową.
    // Mógłbym mieć Polygon, który zwraca true przy IsRectangle lub IsSquare;
    namespace Shapeful
    {
        interface IShape
        {
            float Area { get; }
        }

        public class Rectangle : IShape
        {
            public float Width { get; protected set; }
            public float Height { get; protected set; }

            public float Area => Width * Height;
        }

        public class Square : IShape
        {
            public float Size { get; protected set; }

            public Square(float size)
            {
                Size = size;
            }

            public float Area => Size * Size;
        }

        public class LiskovExample
        {
            public void Execute()
            {
                int w = 4;
                IShape square = new Square(w);
            }
        }
    }

    namespace Exceptional
    {
        public class Rectangle
        {
            public virtual int Width { get; protected set; }
            public virtual int Height { get; protected set; }

            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
            }

        }
        public class Square : Rectangle
        {
            public override int Width { get; protected set; }
            public override int Height { get; protected set; }

            public Square(int width) : base(width, width)
            {}

            public Square(int width, int height) : base(width, height)
            {
                if (width != height)
                    throw new Exception("This is not a square, m8.");
            }
        }

        public class AreaCalculator
        {
            public int CalculateArea(Rectangle rect)
            {
                return rect.Width * rect.Height;
            }
        }

        public class LiskovExample
        {
            public void Execute()
            {
                int w = 4, h = 5;
                Rectangle rect = new Square(w, h);
                AreaCalculator calc = new AreaCalculator();
                Console.WriteLine("prostokąt o wymiarach {0} na {1} ma pole {2}",
                                    w, h, calc.CalculateArea(rect));
            }
        }
    }

    namespace Bad
    {
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }
        }
        public class Square : Rectangle
        {
            public override int Width
            {
                get { return base.Width; }
                set { base.Width = base.Height = value; }
            }
            public override int Height
            {
                get { return base.Height; }
                set { base.Width = base.Height = value; }
            }
        }

        public class AreaCalculator
        {
            public int CalculateArea(Rectangle rect)
            {
                return rect.Width * rect.Height;
            }
        }

        public class LiskovExample
        {
            public void Execute()
            {
                int w = 4, h = 5;
                Rectangle rect = new Square { Width = w, Height = h };
                AreaCalculator calc = new AreaCalculator();
                Console.WriteLine("prostokąt o wymiarach {0} na {1} ma pole {2}",
                                    w, h, calc.CalculateArea(rect));
            }


        }
    }
}
