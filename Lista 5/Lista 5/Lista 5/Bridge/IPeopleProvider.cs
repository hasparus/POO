using System.Collections.Generic;

namespace Lista_5.Bridge
{
    interface IPeopleProvider /*Implementor*/
    {
        IEnumerable<Person> GetPeople();
    }
}