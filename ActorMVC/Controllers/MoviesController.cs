using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;

namespace MvcApp.Controllers
{ 
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

            public MoviesController(AppDbContext context)
            {
                this._context = context;
            }

            public async Task<IActionResult> Index()
            {
                var allMovies = await _context.Movies.ToListAsync();
                return View();
            }
    }
}

