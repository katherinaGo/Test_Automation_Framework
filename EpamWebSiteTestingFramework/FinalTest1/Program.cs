using FinalTest1.Abstract_Interface;
using FinalTest1.CollectionsOfCities;
using FinalTest1.GenericMethod;

var dog = new Dog("Zhoric", 23);
Console.WriteLine("Hello {0} with weight {1} kg!", dog.Name, dog.Weight);
dog.MakeSound();
dog.Walk();

var eagle = new Eagle("Nick", 13);
Console.WriteLine("Hello {0} with weight {1} kg!", eagle.Name, eagle.Weight);
eagle.Fly();


Collections.PrintResultCollection();

Console.WriteLine();

Generics.PrintSmth(3);
Generics.PrintSmth(3.444d);
Generics.PrintSmth("Hello!");
Generics.PrintSmth(new Dog("Vasia", 25));