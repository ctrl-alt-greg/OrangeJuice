using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeJuice.Models
{
	public class Orange
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Farm { get; set; }
		
		// Specifies Display Name
		[Display(Name = "Harvest Date")]
		// Specifies DateTime to just include date
		[DataType(DataType.Date)]
		public DateTime HarvestDate { get; set; }

		// specifies wieght as decimal(precision, scale)
		// precision is the max number of digits needed to express a single weight value
		// scale is the max number of decimals needed
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Weight { get; set; }
	}
}
