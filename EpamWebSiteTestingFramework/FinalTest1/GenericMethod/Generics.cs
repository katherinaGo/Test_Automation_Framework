namespace FinalTest1.GenericMethod;

public class Generics
{
    public static void PrintSmth<T>(T item)
    {
        switch (item)
        {
            case int:
                Console.WriteLine("I am int {0}", item);
                break;
            case string:
                Console.WriteLine("I am string {0}", item);
                break;
            case double:
                Console.WriteLine("I am double {0}", item);
                break;
            default:
                Console.WriteLine("Cucumber, {0} =)", item);
                break;
        }
    }
}