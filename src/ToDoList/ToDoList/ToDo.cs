
namespace ToDoList
{
    internal class ToDo
    {
        public string Description { get; set; }
        public Person Person { get; set; }
        public Category Category { get; set; }
        public string Id { get; set; }
        public DateTime InicialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public bool Status { get; set; }



        public ToDo(string id, DateTime date)
        {
            var construtionID = Guid.NewGuid();
            id = construtionID.ToString();
            InicialDate = date;
        }
    }
    
}
