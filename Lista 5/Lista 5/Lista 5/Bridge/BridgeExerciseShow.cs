using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_5.Bridge
{
    public static class BridgeExerciseShow
    {
        public static void Do()
        {
            var pplStrings = new[]
            {
                "5 Julek",
                "8 Maciek",
                "42 Tomek"
            };

            var ppl = pplStrings.Select(x => new Person(x));

            var registry1 = new PersonRegistryWithConsoleNotification(
                new ListPeopleProvider(ppl));

            var registry2 = new PersonRegistryWithLoudConsoleNotification(
                new ConsolePeopleProvider());

            registry1.Notify();
            registry2.Notify();
        }
    }
}
