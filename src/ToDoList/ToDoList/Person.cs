

namespace ToDoList
{
    internal class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Person()
        {

        }
        public Person(string name, string id)
        {
            var construtionID = Guid.NewGuid();
            id = construtionID.ToString();
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Id}|{Name}";
        }
        public string SetName()
        {
            return $"Id pessoa: {Id} \nNome: {Name}\n";
        }
    }
}
