// See https://aka.ms/new-console-template for more information

using ConsoleTables;
using RandomNameGeneratorLibrary;

internal class Program
{
    public static void Main(string[] args)
    {
        #region numbers1-100
        
        {
            List<int> intsList = new List<int>(Enumerable.Range(1, 100));
        
            Console.WriteLine("All values:");
            PrintList(intsList);
        
            Console.WriteLine("Odd values:");
            PrintList(intsList.Where((x) => x % 2 != 0 ));
        
            Console.WriteLine("Odd values in pow2:");
            var listInPow = intsList.Select(x => Math.Pow(x, 2)).Where((x) => x % 2 != 0);
            PrintList(listInPow);
        
            Console.WriteLine("Odd values in pow2 sum:");
            Console.WriteLine(listInPow.Sum());
        }
        
        #endregion

        #region person

        List<Person> personsList = new List<Person>();
        for (int i = 0; i < 20; i++)
        {
            personsList.Add(
                new Person(Guid.NewGuid(), 
                                new PersonNameGenerator().GenerateRandomFirstName(), 
                                new Random().Next(14, 30)));
        }
        personsList.PrintPersonList();

        PrintList(personsList.Where((person) => person.Age > 20).Select((person) => person.Name));

        var personsOlder20ByName = personsList.Where((person) => person.Age > 20)
            .Select((anonymPerson) => new
            {
                Id = anonymPerson.Id,
                Name = anonymPerson.Name
            }).OrderBy((anonymPerson) =>anonymPerson.Name);
        PrintList(personsOlder20ByName);

        var personsOlder20GroupedByAgeToDictionaryAndAnonym = personsList
                .Where((person) => person.Age > 20)
                .GroupBy((person) => person.Age)
                .ToDictionary(ig => ig.Key, ig => ig.Select(person => new
                {
                    Id = person.Id,
                    Name = person.Name
                }));
        var penultimateValue = personsList.Where(person => person == personsList[personsList.Count - 2]);
        penultimateValue.PrintPersonList();
        
        #endregion
        
        
        
        Console.ReadKey();
    }

    public static void PrintList<T>(IEnumerable<T> list)
    {
        foreach (var value in list)
        {
            Console.Write("{0} ", value);
        }
        Console.WriteLine();
    }
}

public record Person(Guid Id, string Name, int Age);

public static class ListExtention
{
    public static void PrintPersonList(this IEnumerable<Person> personsList)
    {
        var table = new ConsoleTable("Id", "Name", "Age");
        foreach (var person in personsList)
        {
            table.AddRow(person.Id, person.Name, person.Age);
        }
        table.Write();
    }
}