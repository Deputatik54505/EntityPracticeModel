using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.models
{
	public class Zookeeper
	{
		public Zookeeper(string firstName)
		{
			FirstName = firstName;
			Animals = new List<Animal>();
		}

		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		public List<Animal>? Animals { get; set; }

	}
}
