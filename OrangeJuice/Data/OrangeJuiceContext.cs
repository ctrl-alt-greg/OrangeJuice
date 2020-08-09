using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using OrangeJuice.Models;

namespace OrangeJuice.Data
{
	public class OrangeJuiceContext : DbContext
	{
		public OrangeJuiceContext(DbContextOptions<OrangeJuiceContext> options) : base(options)
		{

		}

		public DbSet<Orange> Orange { get; set; }
	}
}
