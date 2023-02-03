namespace FinalTest1.Abstract_Interface;

public class Eagle : Animal, IFlyableAnimal
{
    public override string Name { get; set; }
    public override int Weight { get; set; }

    public Eagle(string name, int weight) : base(name, weight)
    {
        Name = name;
        Weight = weight;
    }

    public override void Sleep()
    {
        Console.WriteLine("I am sleeping on the trees.");
    }

    public override void MakeSound()
    {
        Console.WriteLine("kar kar po orlinomu");
    }

    public void Fly()
    {
        Console.WriteLine("I can fly very fast!");
    }
}