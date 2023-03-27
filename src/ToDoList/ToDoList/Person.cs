

namespace ToDoList
{
    internal class Person
    {
        public string Name { get; set; }
        public string IdPerson { get; set; }

        public Person(string name, string idPerson)
        {
            Name = name;
            var construtionID = Guid.NewGuid();
            idPerson = construtionID.ToString();
        }

    }
}
