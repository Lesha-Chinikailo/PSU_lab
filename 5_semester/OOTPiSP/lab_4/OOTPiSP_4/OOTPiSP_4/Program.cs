namespace OOTPiSP_4;
class Program
{
    static void Main(string[] args)
    {
        Magazine magazine = new Magazine(new PrintText());
        magazine.Print();
        magazine.Printer = new PrintHTML();
        magazine.Print();
        Console.ReadLine();
    }
}
