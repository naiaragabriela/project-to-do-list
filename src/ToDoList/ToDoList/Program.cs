
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
        listTodo = LoadFromFile(listTodo);
        person = LoadFromFilePerson(person);

        WriteFilePerson(person);
        do
        {

            option = Menu(option);
            switch (option)
            {
                default:
                    Console.WriteLine("Opção inválida");
                    break;
                case 1:
                    listTodo.Add(CreatTask(person));
                    WriteFileToDo(listTodo);
                    break;
                case 2:
                    listTodo.Remove(RemoveTask(listTodo));
                    WriteFileToDo(listTodo);
                    break;
                case 3:
                    EditTask(listTodo);
                    break;
                case 4:
                    PrintPerson(person);
                    break;
                case 5:
                    System.Environment.Exit(0);
                    break;
            }
        } while (option != 4);
    }
    
    private static void PrintTask(List<ToDo> listTodo)
    {
        foreach (var item in listTodo)
        {
            Console.WriteLine(item.ToFile());
        }
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
    
    private static List<ToDo> LoadFromFile(List<ToDo> listTodo)
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
            newTodo.Description = values[2];
            newTodo.Status = bool.Parse(values[3]);
            newTodo.DueDate = DateTime.Parse(values[4]);
            newTodo.Category = values[5];
            Person person = new Person();
            person.Id = values[6];
            person.Name = values[7];
            newTodo.Person = person;
            listTodo.Add(newTodo);
        }
        sr.Close();
        return listTodo;
    }

    private static List<Person> LoadFromFilePerson(List<Person> person)
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

        if (person.Count == 0)
        {
            Console.WriteLine("Digite seu nome");
            var namePerson = Console.ReadLine();
            Person personOwner = new Person(namePerson);
            person.Add(personOwner);
        }

        return person;
    }

    private static void WriteFileToDo(List<ToDo> list)
    {
        string toDo = "";
        foreach (ToDo textList in list)
        {
            toDo += textList.ToString() + "\n";
        }
        try
        {
            StreamWriter sw = new StreamWriter("ListToDo.txt");
            if (!string.IsNullOrWhiteSpace(toDo))
            {
                sw.WriteLine(toDo);
            }
            sw.Close();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            Console.WriteLine("Registro Gravado com Sucesso!");
            Thread.Sleep(1000);
        }
    }

    private static ToDo RemoveTask(List<ToDo> listTodo)
    {
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você quer excluir");
        var palavra = Console.ReadLine();

        foreach (var item in listTodo)
        {
            if (item.Description.Contains(palavra))
            {
                return item;
            }
        }
        return null;
    }

    private static void WriteFilePerson(List<Person> people)
    {
        string person = "";
        foreach (Person personList in people)
        {
            person += personList.ToString() + "\n";
        }
        try
        {
            StreamWriter sw = new StreamWriter("ListPerson.txt");
            if (!string.IsNullOrWhiteSpace(person))
            {
                sw.WriteLine(person);
            }
            sw.Close();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            Console.WriteLine("Registro Gravado com Sucesso!");
            Thread.Sleep(1000);
        }
    }

    private static ToDo CreatTask(List<Person> person)
    {
        Console.WriteLine("Digite a descrição para a criação da tarefa: ");
        string descrição = Console.ReadLine();
        foreach (var item in person)
        {
            Console.WriteLine(item.ToString());
        }
        Console.Write("Digite o nome da pessoa para ser a responsável pela tarefa: ");
        string nome = Console.ReadLine();

        foreach (var item in person)
        {
            if (item.Name.Equals(nome))
            {
                ToDo task = new ToDo(descrição, item);
                return task;
            }
        }
        return null;
    }

    private static void PrintPerson(List<Person> person)
    {
        foreach (var item in person)
        {
            Console.WriteLine(item.SetName());
        }
    }

    private static ToDo TaskConcluided(List<ToDo> listTodo)
    {
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você deseja alterar o status:");
        var findTask = Console.ReadLine();
        Console.WriteLine("Digite o número do que você deseja fazer de alteração:");
        Console.WriteLine("1-Alterar Status para finalizada | 2- Alterar Status para não finalizada");
        int change = int.Parse(Console.ReadLine());
        foreach (var item in listTodo)
        {
            if (item.Description.ToLower().Contains(findTask.ToLower()))
            {
             
                item.SetStatus(change);

                return item;
            }
        }
        return null;
    }

    private static void EditTask(List<ToDo> listTodo)
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
                        TaskConcluided(listTodo);
                        break;
                    case 2:
                       // EditAnyTask();
                        break;
                    case 3:
                        break;
                    case 4:
                        PrintTask(listTodo);
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