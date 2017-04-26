using System;
using System.Collections.Generic;

namespace Lista_5.Bridge
{
    class ConsolePeopleProvider : IPeopleProvider
    {
        public IEnumerable<Person> GetPeople()
        {
            string line = Console.ReadLine();
            while (line != "STOP")
            {
                yield return new Person(line);
                line = Console.ReadLine();
            }
        }
    }
}