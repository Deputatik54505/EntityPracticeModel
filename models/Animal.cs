using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Model.models;

namespace Model.models;

[PrimaryKey("Id")]
public class Animal
{
	public Animal(string animalName)
	{
		AnimalName = animalName;
	}

	public Animal(string animalName, Cell cell)
	{
		AnimalName = animalName;
		Cell = cell;
	}
	public int Id { get; set; }
	[Required] public string AnimalName { get; set; }
	[Required] [NotNull] public Cell? Cell { get; set; }
	public Meal? MainMeal { get; set; }

	public List<Zookeeper>? Zookeepers { get; set; }

	public void Print()
	{
		Console.WriteLine(Id);
		Console.WriteLine(AnimalName);
		Console.WriteLine(Cell);
		Console.WriteLine(MainMeal);
		if (Zookeepers != null) Console.WriteLine(Zookeepers.Count);
	}


}