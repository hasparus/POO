using System;

namespace Lista_5.Bridge
{
    class PersonRegistryWithLoudConsoleNotification
        : PersonRegistry
    {
        public PersonRegistryWithLoudConsoleNotification(IPeopleProvider peopleProvider)
        {
            this.poepleProvider = peopleProvider;
        }

        public override void Notify()
        {
            foreach (var person in poepleProvider.GetPeople())
            {
                Console.WriteLine($"Hey, {person.Name}.".ToUpper());
            }
        }
    }
}