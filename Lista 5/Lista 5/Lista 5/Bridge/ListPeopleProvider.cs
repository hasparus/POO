using System.Collections.Generic;
using System.Linq;

namespace Lista_5.Bridge
{
    class ListPeopleProvider : IPeopleProvider
    {
        readonly List<Person> people;

        public ListPeopleProvider(IEnumerable<Person> ppl)
        {
            people = ppl.ToList();
        }


        public IEnumerable<Person> GetPeople()
        {
            return people;
        }
    }
}