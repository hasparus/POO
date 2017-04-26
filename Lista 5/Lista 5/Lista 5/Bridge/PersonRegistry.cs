using System;
using System.Collections.Generic;

namespace Lista_5.Bridge
{
    namespace Old
    {
        class PersonRegistry
        {
            /// <summary>
            /// Pierwszy stopień swobody - różne wczytywanie
            /// </summary>
            public List<Person> People = new List<Person>();

            /// <summary>
            /// Drugi stopień swobody - różne użycie
            /// </summary>
            public void NotifyPersons()
            {
                foreach (Person person in People)
                    Console.WriteLine(person);
            }
        }
    }

    abstract class PersonRegistry
    {
        protected IPeopleProvider poepleProvider;
        public abstract void Notify();
    }
}
