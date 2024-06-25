using Domain.Model;

var plugboard = new Plugboard("ABCDEFGH");

Console.WriteLine(plugboard.Process('A'));
Console.WriteLine(plugboard.Process('B'));
Console.WriteLine(plugboard.Process('X'));
Console.WriteLine(plugboard.Process('.'));

Console.ReadKey();

