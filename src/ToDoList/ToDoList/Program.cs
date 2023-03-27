using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
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
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }while (option != 4);
    }

    private static int Menu(int options)
    {
        Console.WriteLine("Menu de opções");
        Console.WriteLine("1 - Adicionar tarefa");
        Console.WriteLine("2- Remover tarefa");
        Console.WriteLine("3 - Editar tarefa");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma das opções: ");
        options = int.Parse(Console.ReadLine());
        return options;
    }
}