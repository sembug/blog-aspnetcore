using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly BlogContext _context;

        public CategoryList(BlogContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<Category>> GetItemsAsync()
        {
            return _context.Categories.ToListAsync();
        }
    }
}