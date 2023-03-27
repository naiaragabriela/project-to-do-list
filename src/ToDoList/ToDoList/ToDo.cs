
namespace ToDoList
{
    internal class ToDo
    {
        public string Description { get; set; }
        public Person Person { get; set; }
        public Category Category { get; set; }
        public string Id { get; set; }
        public DateTime CriatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public ToDo(string id, DateTime date)
        {
            var construtionID = Guid.NewGuid();
            id = construtionID.ToString();
            Id = id;
            date = DateTime.Now;
            CriatedDate = date;
        }

        public override string ToString()
        {
            return $"{Id}|{CriatedDate}|{Category}|{Description}|{Person}|{Status}|{DueDate}|";
        }

        public string ToUser() 
        { 
        return $"ID:{Id}|Data criada: {CriatedDate}|{Category}|{Description}|{Person}|{Status}|{DueDate}|";
        }

    }
    
}
