using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Mvc.Rendering;

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
		public string Juiciness { get; set; }
	}

	public class FarmViewModel
	{
		public List<Orange> Oranges { get; set; }
		public SelectList Farms { get; set; }
		public string OrangeFarm { get; set; }
		public string SearchString { get; set; }
	}
}