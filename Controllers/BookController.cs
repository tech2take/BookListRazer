using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazer.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var itemToDelete = _db.Book.FirstOrDefault(m => m.Id == id);

            if (itemToDelete == null)
            {
                return Json(new { success = false, message = "Error While deleting." });
            }

            _db.Book.Remove(itemToDelete);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Deleted successfully." });
        }


    }
}