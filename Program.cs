Console.WriteLine("What is your age?");
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("What is the age of the student next to you?");
int studentage = Convert.ToInt32(Console.ReadLine());
if (age == studentage)
{
    Console.WriteLine("Your ages are equal");
} 
else if (age < studentage)
{
    Console.WriteLine("You are younger");
}    
else if (age > studentage)
{
    Console.WriteLine("You are older");
}    