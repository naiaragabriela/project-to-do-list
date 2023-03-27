

namespace ToDoList
{
    internal class Person
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Person(string name, Guid id)
        {
            Name = name;
            var construtionID = Guid.NewGuid();
            id = construtionID.ToString();
        }

    }
}
