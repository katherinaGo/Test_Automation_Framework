namespace FinalTest1;

public abstract class Animal
{
    public abstract string Name { get; set; }
    public abstract int Weight { get; set; }

    protected Animal(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    public abstract void Sleep();
    public abstract void MakeSound();
}