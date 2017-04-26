using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_5.Bridge
{
    class PersonRegistryWithConsoleNotification
        : PersonRegistry
    {
        public PersonRegistryWithConsoleNotification(IPeopleProvider peopleProvider)
        {
            this.poepleProvider = peopleProvider;
        }

        public override void Notify()
        {
            foreach (var person in poepleProvider.GetPeople())
            {
                Console.WriteLine($"Hey, {person.Name}.");
            }
        }
    }
}
