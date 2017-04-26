namespace Lista_5.Bridge
{
    class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Person(string s)
        {
            // 5 Michał
            var a = s.Split();
            Id = int.Parse(a[0]);
            Name = a[1];
        }
    }
}