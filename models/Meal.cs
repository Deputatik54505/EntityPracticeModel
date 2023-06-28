using System.ComponentModel.DataAnnotations;

namespace Model.models;

public class Meal
{
	public int Id { get; set; }
	[Required]
	public string Name { get; set; }
}