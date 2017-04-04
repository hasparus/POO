using System;

namespace Lista_4.ShapesAndFactories
{
    class Disc : IShape
    {
        readonly double radius;

        private Disc(double radius)
        {
            this.radius = radius;
        }

        public class DiscFactoryWorker : IShapeFactoryWorker
        {
            public string ShapeName { get; } = "Disc";

            public IShape Create(params object[] parameters)
            {
                var radius = (double) parameters[0];
                return new Disc(radius);
            }
        }

        public double Area()
            => Math.PI * radius * radius;
    }
}
