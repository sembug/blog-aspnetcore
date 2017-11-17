using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.ViewModels;

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
        private Task<List<CategoryViewModel>> GetItemsAsync()
        {
            return _context.Categories
                .Include(c => c.Posts)
                .Select(r => new CategoryViewModel
                {
                    Category = r,
                    PostsCount = r.Posts.Count()
                })
                .ToListAsync();
        }
    }
}