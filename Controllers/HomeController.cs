using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext _context;

        public HomeController(BlogContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.Include(c => c.Category).ToListAsync();
            return View(posts);
        }

        public async Task<IActionResult> Post(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(c => c.Category).SingleOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
