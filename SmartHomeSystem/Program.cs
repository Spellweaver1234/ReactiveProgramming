namespace SmartHomeSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var homeSystem = new SmartHomeSystem();
        homeSystem.Start();

        Console.WriteLine("Система управления умным домом запущена");
        Console.ReadLine();
    }
}