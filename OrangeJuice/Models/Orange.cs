using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrangeJuice.Models
{
	public class Orange
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Farm { get; set; }
		
		// Specifies DateTime to just include date
		[DataType(DataType.Date)]
		public DateTime HarvestDate { get; set; }

		public decimal Weight { get; set; }
	}
}
