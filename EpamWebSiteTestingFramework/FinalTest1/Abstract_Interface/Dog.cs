namespace FinalTest1.Abstract_Interface;

public class Dog : Animal, IWalkableAnimal
{
    public Dog(string name, int weight) : base(name, weight)
    {
        Name = name;
        Weight = weight;
    }

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


    public void Walk()
    {
        Console.WriteLine("I am walking and running.");
    }

    public override string ToString()
    {
        return ($"I am {Name}").ToString();
    }
}