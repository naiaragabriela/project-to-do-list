using System.ComponentModel.Design;
using ToDoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> pessoas = new List<Person>();
        List<Category> categorias = new List<Category>();

        LoadFromFile();

        int option = 0;
        do
        {
            option = Menu(option);
            switch (option)
            {
                default:
                    Console.WriteLine("Opção inválida");
                    break;
                case 1:
                    break;
                case 2:
                    RemoveTask();
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
    }

    private static void PrintTask()
    {
    }

    private static void EditTask()
    {
        //foreach (var item in listTodo)
        //{
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
        //}
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

    private static void RemoveTask()
    {
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