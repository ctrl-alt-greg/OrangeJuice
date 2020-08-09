using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrangeJuice.Data;
using System;
using System.Linq;

namespace OrangeJuice.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new OrangeJuiceContext(serviceProvider.GetRequiredService<DbContextOptions<OrangeJuiceContext>>()))
			{
				// Return if there are already Orangers in the DB
				if (context.Orange.Any())
				{
					return;
				}

				// Seed the DB
				context.Orange.AddRange(
					new Orange
					{
						Name = "O.G.O.J.",
						Farm = "Happy Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 2.9M
					},
					new Orange
					{
						Name = "O.J. II",
						Farm = "Happy Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 1.5M
					},
					new Orange
					{
						Name = "Orange the Third",
						Farm = "Happy Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 0.8M
					},
					new Orange
					{
						Name = "Blind Guy McSqueezy",
						Farm = "Dunder-Mifflin Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 1.65M
					},
					new Orange
					{
						Name = "Mr. Ping",
						Farm = "Dunder-Mifflin Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 2.85M
					},
					new Orange
					{
						Name = "Michael Klump",
						Farm = "Dunder-Mifflin Orange Farms",
						HarvestDate = DateTime.Today,
						Weight = 420.69M
					}
				);
			}
		}
	}
}
