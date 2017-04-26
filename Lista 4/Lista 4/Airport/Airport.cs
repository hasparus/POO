using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_4.Airport
{
    public class Airport
    {
        HashSet<Plane> planesSet;
        Queue<Plane> freePlanesQueue;

        public void Initialize(int poolSize)
        {
            freePlanesQueue = new Queue<Plane>(poolSize);
            for (var i = 0; i < poolSize; ++i)
            {
                var p = new Plane(this);
                freePlanesQueue.Enqueue(p);
                planesSet.Add(p);
            }
        }

        public Plane Give()
        {
            if (freePlanesQueue.Count == 0)
            {
                // throw new Exception("Plane pool empty.");
                return null;
            }
            var p = freePlanesQueue.Dequeue();;
            planesSet.Remove(p);
            return p;
        }

        public void Take(Plane plane)
        {
            plane.Airport = this;
            
        }
    }

    public class Plane
    {
        public Airport Airport { get; internal set; }

        internal Plane(Airport almaMater)
        {
            Airport = almaMater;
        }
    }
}
