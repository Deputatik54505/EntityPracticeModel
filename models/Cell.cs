using System.ComponentModel.DataAnnotations;
using Model.models;

namespace Model.models;

public class Cell
{
	public int Id { get; set; }
	[Required] public List<Animal> Animals { get; set; } = new();
}