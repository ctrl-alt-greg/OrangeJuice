using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrangeJuice.Data;
using OrangeJuice.Models;

namespace OrangeJuice.Controllers
{
	public class OrangesController : Controller
	{
		private readonly OrangeJuiceContext _context;

		public OrangesController(OrangeJuiceContext context)
		{
			_context = context;
		}

		// GET: Oranges
		public async Task<IActionResult> Index(string selectedFarm, string searchString) 
		{
			// Use LINQ to get list of genres
			// Delayed Query Execution
			IQueryable<string> farmQuery = 
				from o in _context.Orange 
				orderby o.Farm 
				select o.Farm;

			var oranges = from o in _context.Orange select o;

			if(!String.IsNullOrEmpty(searchString))
			{
				oranges = oranges.Where(o => o.Name.Contains(searchString));
			}

			if(!String.IsNullOrEmpty(selectedFarm))
			{
				oranges = oranges.Where(o => o.Farm == selectedFarm);
			}

			var farmVM = new FarmViewModel
			{
				Farms = new SelectList(await farmQuery.Distinct().ToListAsync()),
				Oranges = await oranges.ToListAsync(),
				// NEED THIS LINE to make select list stay on selected item
				// See Orange.cs for more detailss
				SelectedFarm = selectedFarm
			};

			return View(farmVM);
		}

		// GET: Oranges/Details/id
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var orange = await _context.Orange.FirstOrDefaultAsync(m => m.Id == id);

			if (orange == null)
			{
				return NotFound();
			}

			return View(orange);
		}

		// GET: Oranges/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Oranges/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Farm,HarvestDate,Weight,Juiciness")] Orange orange)
		{
			// ModelState.IsValid checks any validation rules added to Orange.cs
			if (ModelState.IsValid)
			{
				_context.Add(orange);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(orange);
		}

		// GET: Oranges/Edit/id
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var orange = await _context.Orange.FindAsync(id);
			if (orange == null)
			{
				return NotFound();
			}
			return View(orange);
		}

		// POST: Oranges/Edit/id
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Farm,HarvestDate,Weight,Juiciness")] Orange orange)
		{
			if (id != orange.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(orange);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!OrangeExists(orange.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(orange);
		}

		// GET: Oranges/Delete/id
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var orange = await _context.Orange
				.FirstOrDefaultAsync(m => m.Id == id);
			if (orange == null)
			{
				return NotFound();
			}

			return View(orange);
		}

		// POST: Oranges/Delete/id
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var orange = await _context.Orange.FindAsync(id);
			_context.Orange.Remove(orange);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool OrangeExists(int id)
		{
			return _context.Orange.Any(e => e.Id == id);
		}
	}
}
