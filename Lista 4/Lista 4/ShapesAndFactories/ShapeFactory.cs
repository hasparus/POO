using System;
using System.Collections.Generic;

namespace Lista_4.ShapesAndFactories
{
    class ShapeFactory
    {
        readonly Dictionary<string, IShapeFactoryWorker> workers = 
            new Dictionary<string, IShapeFactoryWorker>();

        public void RegisterWorker(IShapeFactoryWorker worker)
        {
            workers[worker.ShapeName] = worker;
        }

        public IShape CreateShape(string shapeName, params object[] parameters)
        {
            if (workers.ContainsKey(shapeName))
                return workers[shapeName].Create(parameters);
            else return null;
        }
    }

    class ShapeFactoryTest
    {
        public static void Execute()
        {
            var factory = new ShapeFactory();
            
            factory.RegisterWorker(new Disc.DiscFactoryWorker());
            var disc = factory.CreateShape("Disc", 7.0);
            Console.WriteLine(disc.Area());

            factory.RegisterWorker(new Rectangle.RectangleFactoryWorker());
            var rect = factory.CreateShape("Rectangle", 4.0, 5.0);
            Console.WriteLine(rect.Area());
        }
    }
}