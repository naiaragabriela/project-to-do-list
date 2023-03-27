using System.ComponentModel.Design;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using ToDoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> category = new List<string>();
        List<ToDo> listTodo = new List<ToDo>();
        List<Person> person = new List<Person>();

        category.Add("Importante");
        category.Add("Pessoal");
        category.Add("Profissional");

        int option = 0;
        do
        {
            listTodo = LoadFromFile();
            person = LoadFromFilePerson();

            option = Menu(option);
            switch (option)
            {
                default:
                    Console.WriteLine("Opção inválida");
                    break;
                case 1:
                    break;
                case 2:
                    listTodo.Remove(RemoveTask());
                    break;
                case 3:
                    MenuEditTask();
                    break;
                case 4:
                    break;
                case 5:
                    System.Environment.Exit(0);
                    break;
            }
        } while (option != 4);

        List<ToDo> LoadFromFile()
        {
            if (!File.Exists("ListToDo.txt"))
            {
                StreamWriter sw = new StreamWriter("ListToDo.txt");
                sw.Close();
            }
            StreamReader sr = new StreamReader("ListToDo.txt");
            string textList = "";

            while (!string.IsNullOrEmpty(textList = sr.ReadLine()))
            {
                var values = textList.Split('|');
                ToDo newTodo = new ToDo();
                newTodo.Id = values[0];
                newTodo.CriatedDate = DateTime.Parse(values[1]);
                newTodo.Category = values[2];
                newTodo.Description = values[3];
                Person person = new Person();
                person.Id = values[4];
                person.Name = values[5];
                newTodo.Person = person;
                newTodo.Status = bool.Parse(values[6]);
                newTodo.DueDate = DateTime.Parse(values[7]);
                listTodo.Add(newTodo);
            }
            sr.Close();
            return listTodo;
        }

        List<Person> LoadFromFilePerson()
        {
            if (!File.Exists("ListPerson.txt"))
            {
                StreamWriter sw = new StreamWriter("ListPerson.txt");
                sw.Close();
            }
            StreamReader sr = new StreamReader("ListPerson.txt");
            string personList = "";

            while (!string.IsNullOrEmpty(personList = sr.ReadLine()))
            {
                var values = personList.Split('|');
                Person newPerson = new Person();
                newPerson.Id = values[0];
                newPerson.Name = values[1];
                person.Add(newPerson);
            }
            sr.Close();
            return person;
        }

        ToDo RemoveTask()
        {
            Console.WriteLine("Digite uma palavra da descrição da tarefa que você quer excluir");
            foreach (var item in listTodo)
            {
                return item;
            }
            return null;
        }


        void EditTask()
        {
            foreach (var item in listTodo)
            {
                int x = 1;
                while (x != 4)
                {
                    x = MenuEditTask();
                    switch (x)
                    {
                        default:
                            Console.WriteLine("Opção inválida!!");
                            break;
                        case 1:
                            TaskConcluided();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                    }
                }
            }
        }
    }

    private static void PrintTask()
    {
    }


    private static void TaskConcluided()
    {
    }


    private static int MenuEditTask()
    {
        int options;

        Console.WriteLine("Menu de opções para edição das tarefas");
        Console.WriteLine("1 - Marcar status da tarefa");
        Console.WriteLine("2 - Editar tarefa");
        Console.WriteLine("3 - Mudar categorias da tarefa");
        Console.WriteLine("4 - Mostrar tarefas");
        Console.WriteLine("5 - Adicionar categorias");
        Console.WriteLine("6 - Sair");
        Console.WriteLine("Escolha uma das opções: ");


        options = int.Parse(Console.ReadLine());
        return options;
    }

    private static List<ToDo> LoadFromFile()
    {
        if (!File.Exists("ListToDo.txt"))
        {
            StreamWriter sw = new StreamWriter("ListToDo.txt");
            sw.Close();
        }
        StreamReader sr = new StreamReader("ListToDo.txt");
        string textList = "";
        List<ToDo> listTodo = new List<ToDo>();
        while (!string.IsNullOrEmpty(textList = sr.ReadLine()))
        {
            var values = textList.Split('|');

        }
        sr.Close();
        return listTodo;
    }


    private static void CreateTask()
    {
    }

    private static int Menu(int options)
    {
        int option;
        Console.WriteLine("Menu de opções");
        Console.WriteLine("1 - Adicionar tarefa");
        Console.WriteLine("2 - Remover tarefa");
        Console.WriteLine("3 - Editar/Adicionar Tarefas, Pessoas e Categorias");
        Console.WriteLine("4 - Mostrar as pessoas já cadastradas");
        Console.WriteLine("5 - Sair");
        Console.Write("Escolha uma das opções: ");

        options = int.Parse(Console.ReadLine());
        Console.WriteLine("\n\n");
        return options;
    }
}