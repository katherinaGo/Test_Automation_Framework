using FinalTest1.Abstract_Interface;
using FinalTest1.CollectionsOfCities;

var dog = new Dog("Zhoric", 23);
Console.WriteLine("Hello {0} with weight {1} kg!", dog.Name, dog.Weight);
dog.MakeSound();
dog.Walk();

var eagle = new Eagle("Nick", 13);
Console.WriteLine("Hello {0} with weight {1} kg!", eagle.Name, eagle.Weight);
eagle.Fly();



Collections.PrintResultCollection();