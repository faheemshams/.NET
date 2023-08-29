using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;

namespace MvcApp.Controllers
{
	public class ActorsController : Controller
	{
		private readonly AppDbContext _context;

		public ActorsController(AppDbContext context)
		{
			this._context = context;
		}

		public async Task<IActionResult> Index()
		{
			var allActors = await _context.Actors.ToListAsync();
			return View(allActors);
		}
	}
}

