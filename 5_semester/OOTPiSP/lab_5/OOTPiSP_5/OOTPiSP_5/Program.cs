namespace OOTPiSP_5;
class Program
{
    static void Main(string[] args)
    {
        Magazine magazine = new Magazine();
        Teacher teacher = new Teacher("Mark", magazine);
        Student student = new Student("Lesha", magazine);

        teacher.ShowItemAt(0);
        student.ShowItemAt(1);

        student.Unsubscribe();

        student.ShowItemAt(2);

        student.Subscribe(magazine);

        Console.Read();
    }
}