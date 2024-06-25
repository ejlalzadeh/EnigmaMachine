using Domain.Model;

var plugboard = new Plugboard("AXBCDEQOFH");

Console.WriteLine(plugboard.Process('A'));
Console.WriteLine(plugboard.Process('Q'));
Console.WriteLine(plugboard.Process('X'));
Console.WriteLine(plugboard.Process('.'));

Console.ReadKey();

