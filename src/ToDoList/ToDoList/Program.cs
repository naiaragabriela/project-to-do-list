using System.ComponentModel.Design;
using ToDoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> pessoas = new List<Person>();
        List<Category> categorias = new List<Category>();

        //LoadFromFile(listTodo);
        //LoadFromFile(categorias);

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
                    CreateTask();
                    break;
                case 2:
                    RemoveTask();
                    break;
                case 3:
                    EditTask();
                    MenuEditTask();
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
            }
        }while (option != 4);
    }

    private static void EditTask()
    {
        do
        {

        } while ();
    }

    private static int MenuEditTask()
    {
        int options;
        Console.WriteLine("Menu de opções para edição das tarefas");
        Console.WriteLine("1 - Marcar tarefa como concluída");
        Console.WriteLine("2 - Mudar a tarefa de concluída para não concluída");
        Console.WriteLine("3 - Editar Pessoa");
        Console.WriteLine("4 - Mudar categorias da tarefa");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("Escolha uma das opções");
        options = int.Parse(Console.ReadLine());
        return options;
    }

    List<ToDo> LoadFromFile()
    {
        if(!File.Exists("ListToDo.txt"))
        {
            StreamWriter sw = new StreamWriter("ListToDo.txt");
            sw.Close();
        }
        StreamReader sr = new StreamReader("ListToDo.txt");
        string textList = "";
        List<ToDo> listTodo = new List<ToDo>();
        
        // falta!!! ler o arquivo que está salvo e transformar cada informação da lista em objeto
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
        Console.WriteLine("2- Remover tarefa");
        Console.WriteLine("3 - Editar tarefa");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma das opções:");
        options = int.Parse(Console.ReadLine());
        return options;
    }
}