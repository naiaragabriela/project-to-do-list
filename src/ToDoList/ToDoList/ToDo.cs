
namespace ToDoList
{
    internal class ToDo
    {
        public string Description { get; set; }
        public Person Person { get; set; }
        public Category Category { get; set; }
        public string Id { get; set; }


        public ToDo(string id)
        {
            var construtionID = Guid.NewGuid();
            id = construtionID.ToString();
        }
    }
    }
}
