using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_4.ShapesAndFactories
{
    public class Rectangle : IShape
    {
        readonly double width;
        readonly double height;

        private Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public class RectangleFactoryWorker : IShapeFactoryWorker
        {
            public string ShapeName { get; } = "Rectangle";

            public IShape Create(params object[] parameters)
            {
                var width = (double) parameters[0];
                var height = (double) parameters[1];
                return new Rectangle(width, height);
            }    
        }

        public double Area()
            => width * height;
    }
}
