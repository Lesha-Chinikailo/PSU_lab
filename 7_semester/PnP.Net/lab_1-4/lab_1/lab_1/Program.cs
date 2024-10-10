using lab_1.tasks;

namespace lab_1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");


        while (true)
        {
            PrintMenu();
            int choosedNumber = int.Parse(Console.ReadLine());
            switch (choosedNumber)
            {
                case 0:
                    Task2.run(new double[,]
                    {
                    { 11.1, 12.2, 13.7 },
                    { 19, 21.1, 21.1 },
                    { 19.0, 6.7, 8.9 }
                    });
                    break;
                case 1:
                    Console.WriteLine("введите строку:");
                    string str = Console.ReadLine();
                    Task3.run(str);
                    break;
                case 2:
                    Task4.run("htht3.j@pdu.by " +
                          "lesha.2222@mail.ru " +
                          "bgdvhfbvjd@ " +
                          "njvfj@gmail.com" +
                          "jbvdjbvj&gmail.com");
                    break;
                default:
                    return;
            }

        }


    }

    static void PrintMenu()
    {
        Console.WriteLine("0 - задание №2");
        Console.WriteLine("1 - задание №3");
        Console.WriteLine("2 - задание №4");
        Console.WriteLine("любое число - выход");
        Console.Write("введите номер задания: ");
    }
}


