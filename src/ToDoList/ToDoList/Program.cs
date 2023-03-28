using ToDoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> categories = new List<string>();
        List<ToDo> toDoList = new List<ToDo>();
        List<Person> personList = new List<Person>();

        categories.Add("Importante");
        categories.Add("Pessoal");
        categories.Add("Profissional");

        int option = 0;
        toDoList = LoadFromFile(toDoList);
        personList = LoadFromFilePerson(personList);

        WriteFilePerson(personList);
        do
        {

            option = Menu(option);
            switch (option)
            {
                default:
                    Console.WriteLine("Opção inválida");
                    break;
                case 1:
                    toDoList.Add(CreateTask(personList, categories));
                    WriteFileToDo(toDoList);
                    break;
                case 2:
                    toDoList.Remove(RemoveTask(toDoList));
                    WriteFileToDo(toDoList);
                    break;
                case 3:
                    EditTask(toDoList, categories);
                    break;
                case 4:
                    PrintPerson(personList);
                    break;
                case 5:
                    System.Environment.Exit(0);
                    break;
            }
        } while (option != 4);
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
    private static int MenuEditTask()
    {
        int options;

        Console.WriteLine("Menu de opções para edição das tarefas");
        Console.WriteLine("1 - Marcar status da tarefa");
        Console.WriteLine("2 - Editar tarefa");
        Console.WriteLine("3 - Mudar categorias da tarefa");
        Console.WriteLine("4 - Mostrar tarefas");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("Escolha uma das opções: ");

        options = int.Parse(Console.ReadLine());
        return options;
    }
    private static List<ToDo> LoadFromFile(List<ToDo> toDoList)
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
            toDoList.Add(newTodo);
        }
        sr.Close();
        return toDoList;
    }
    private static List<Person> LoadFromFilePerson(List<Person> personList)
    {
        if (!File.Exists("ListPerson.txt"))
        {
            StreamWriter sw = new StreamWriter("ListPerson.txt");
            sw.Close();
        }
        
        StreamReader sr = new StreamReader("ListPerson.txt");
        string people = "";

        while (!string.IsNullOrEmpty(people = sr.ReadLine()))
        {
            var values = people.Split('|');
            Person newPerson = new Person();
            newPerson.Id = values[0];
            newPerson.Name = values[1];
            personList.Add(newPerson);
        }
        sr.Close();

        if (personList.Count == 0)
        {
            Console.WriteLine("Digite seu nome");
            var namePerson = Console.ReadLine();
            Person personOwner = new Person(namePerson);
            personList.Add(personOwner);
        }

        return personList;
    }
    private static void WriteFileToDo(List<ToDo> toDoList)
    {
        string toDo = "";
        foreach (ToDo textList in toDoList)
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
    private static void WriteFilePerson(List<Person> personList)
    {
        string people = "";
        foreach (Person person in personList)
        {
            people += personList.ToString() + "\n";
        }
        try
        {
            StreamWriter sw = new StreamWriter("ListPerson.txt");
            if (!string.IsNullOrWhiteSpace(people))
            {
                sw.WriteLine(people);
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
    private static void PrintPerson(List<Person> personList)
    {
        foreach (var item in personList)
        {
            Console.WriteLine(item.SetName());
        }
    }
    private static void EditTask(List<ToDo> toDoList, List<string> categories)
    {
        foreach (var item in toDoList)
        {
            int x = 1;
            int index = 0;
            while (x != 4)
            {
                x = MenuEditTask();
                switch (x)
                {
                    default:
                        Console.WriteLine("Opção inválida!!");
                        break;
                    case 1:
                        var taskCompleted = ChangeTaskToCompleted(toDoList);
                        index = toDoList.IndexOf(taskCompleted);
                        toDoList[index] = taskCompleted;
                        WriteFileToDo(toDoList);
                        break;
                    case 2:
                       // EditAnyTask();
                       //tem que ter o edit pessoa
                       //edit descrição
                       //edit datafinal 
                        break;
                    case 3:
                        var taskChanged = ChangeTaskCategory(toDoList, categories);
                        index = toDoList.IndexOf(taskChanged);
                        toDoList[index] = taskChanged;
                        WriteFileToDo(toDoList);
                        break;
                    case 4:
                        PrintTask(toDoList);
                        break;
                    case 5:
                        break;
                }
            }
        }
    }
    private static void PrintTask(List<ToDo> toDoList)
    {
        foreach (var item in toDoList)
        {
            Console.WriteLine(item.ToFile());
        }
    }
    private static ToDo RemoveTask(List<ToDo> toDoList)
    {
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você quer excluir");
        var palavra = Console.ReadLine();

        foreach (var item in toDoList)
        {
            if (item.Description.Contains(palavra))
            {
                return item;
            }
        }
        return null;
    }
    private static ToDo CreateTask(List<Person> personList, List<string> categories)
    {
        Console.WriteLine("Digite a descrição para a criação da tarefa: ");
        string description = Console.ReadLine();
        foreach (var item in personList)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Digite o nome da pessoa para ser a responsável pela tarefa: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o número da categoria da sua tarefa: (0) Importante | (1) Pessoal | (2)Profisisonal");
        int indexCategory = int.Parse(Console.ReadLine());

        foreach (var item in personList)
        {
            if (item.Name.Equals(nome))
            {
                ToDo task = new ToDo(description);
                task.SetPerson(item);
                task.Category = categories[indexCategory]; 
                return task;
            }
        }
        return null;
    }
    private static ToDo ChangeTaskToCompleted(List<ToDo> toDoList)
    {
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você deseja alterar o status:");
        var findTask = Console.ReadLine();
        Console.WriteLine("Digite o número do que você deseja fazer de alteração:");
        Console.WriteLine("1-Alterar Status para finalizada | 2- Alterar Status para não finalizada");
        int change = int.Parse(Console.ReadLine());
        foreach (var item in toDoList)
        {
            if (item.Description.ToLower().Contains(findTask.ToLower()))
            {
             
                item.SetStatus(change);

                return item;
            }
        }
        return null;
    }
    private static ToDo ChangeTaskCategory(List<ToDo> toDoList, List<string>categories)
    {
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você alterar a categoria");
        var findTask = Console.ReadLine();
        Console.WriteLine("Digite o número da categoria da sua tarefa: (0) Importante | (1) Pessoal | (2)Profisisonal");
        int indexCategory = int.Parse(Console.ReadLine());
        foreach (var item in toDoList)
        {
            if (item.Description.ToLower().Contains(findTask.ToLower()))
            {

                item.Category = categories[indexCategory];
                return item;
            }
        }
        return null;
    }

    private static void EditAnyTask(List<ToDo> todolist, List<Person> person)
    {
        PrintTask(todolist);
        Console.WriteLine("Digite uma palavra da descrição da tarefa que você quer editar");
        var palavra = Console.ReadLine();
        string description = "";
        foreach (var item in todolist)
        {
            if (item.Description.Contains(palavra))
            {
                Console.Write("Digite a descrição nova para a tarefa: ");
                description = Console.ReadLine() + "\n\n";
                item.Description = description;
                PrintPerson(person);
                Console.WriteLine("Agora digite um nome entre os nomes de pessoas registradas para\n");
                Console.WriteLine("referencia-la na tarefa");
                string name = Console.ReadLine();
                foreach(var items in person)
                {
                    if (items.Name.Equals(name))
                    {
                        item.Person = items;
                    }
                }
            }
        }
    }
}