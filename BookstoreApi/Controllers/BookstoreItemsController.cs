using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookstoreApi.Models;

namespace BookstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreItemsController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public BookstoreItemsController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: api/BookstoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookstoreItem>>> GetBookstoreItems()
        {
            return await _context.BookstoreItems.ToListAsync();
        }

        // GET: api/BookstoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookstoreItem>> GetBookstoreItem(long id)
        {
            var bookstoreItem = await _context.BookstoreItems.FindAsync(id);

            if (bookstoreItem == null)
            {
                return NotFound();
            }

            return bookstoreItem;
        }

        // PUT: api/BookstoreItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookstoreItem(long id, BookstoreItem bookstoreItem)
        {
            if (id != bookstoreItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookstoreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookstoreItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookstoreItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookstoreItem>> PostBookstoreItem(BookstoreItem bookstoreItem)
        {
            _context.BookstoreItems.Add(bookstoreItem);
            await _context.SaveChangesAsync();

        //   return CreatedAtAction("GetBookstoreItem", new { id = bookstoreItem.Id }, bookstoreItem);
             return CreatedAtAction(nameof(GetBookstoreItem), new { id = bookstoreItem.Id }, bookstoreItem);
        }

        // DELETE: api/BookstoreItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookstoreItem(long id)
        {
            var bookstoreItem = await _context.BookstoreItems.FindAsync(id);
            if (bookstoreItem == null)
            {
                return NotFound();
            }

            _context.BookstoreItems.Remove(bookstoreItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookstoreItemExists(long id)
        {
            return _context.BookstoreItems.Any(e => e.Id == id);
        }
    }
}
