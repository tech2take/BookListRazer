using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookListRazer.Model;

namespace BookListRazer.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookListRazer.Model.ApplicationDbContext _context;

        public IndexModel(BookListRazer.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Book.ToListAsync();
        }
    }
}
