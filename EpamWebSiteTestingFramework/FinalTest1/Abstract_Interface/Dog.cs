namespace FinalTest1.Abstract_Interface;

public class Dog : Animal, IWalkableAnimal
{
    public override string Name { get; set; }
    public override int Weight { get; set; }

    public override void MakeSound()
    {
        Console.WriteLine("bark bark");
    }

    public override void Sleep()
    {
        Console.WriteLine("I'm sleeping...");
    }

    public Dog(string name, int weight) : base(name, weight)
    {
        Name = name;
        Weight = weight;
    }

    public void Walk()
    {
        Console.WriteLine("I am walking and running.");
    }
}