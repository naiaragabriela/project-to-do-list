
namespace ToDoList
{
    internal class ToDo
    {
        public string Description { get; set; }
        public Person Person { get; set; }
        public string Category { get; set; }
        public string Id { get; set; }
        public DateTime CriatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public ToDo()
        { }
        public ToDo(string description, Person person)
        {
            var construtionID = Guid.NewGuid();
            var id = construtionID.ToString();
            Id = id;
            var date = DateTime.Now;
            CriatedDate = date;
            Description = description;
            //DueDate = duodate;
            Person = person;
        }
        public override string ToString()
        {
            return $"{Id}|{CriatedDate}|{Description}|{Status}|{DueDate}|{Category}|{Person}";
        }
        public string ToFile()
        {
            return $"ID:{Id}|\nData criada: {CriatedDate}|\nCategoria: {Category}|\nDescrição: {Description}|\nResponsável da tarefa: {Person}|\nStatus da tarefa: {Status}|\nData de Conclusão: {DueDate}";
        }

        public void SetStatus(int change)
        {
            if (change == 1)
            {
                this.Status = true;
            }
            if (change == 2)
            {
                this.Status = false;
            }

        }
        //public string SetPerson()
        //{

        //    return null;


        //}
    }

}
