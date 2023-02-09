Console.WriteLine("Give some text");
string text = Console.ReadLine();

Console.WriteLine("What do you want to do with this text?");
Console.WriteLine("U: make all uppercase");
Console.WriteLine("L: make all lowercase");
Console.WriteLine("Any other key: do not change");
string choice = Console.ReadLine();

if (choice.ToUpper() == "U")
{
    string newText = text.ToUpper();
        Console.WriteLine(newText);
}
else if (choice.ToUpper() == "L")
{
    string newText = text.ToLower();
    Console.WriteLine(newText);
}
else
{
    string newText = text;
    Console.WriteLine(newText);
}