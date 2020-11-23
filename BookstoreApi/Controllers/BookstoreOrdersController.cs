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
    public class BookstoreOrdersController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public BookstoreOrdersController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: api/BookstoreOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookstoreOrder>>> GetBookstoreOrder()
        {
            return await _context.BookstoreOrder.ToListAsync();
        }

        // GET: api/BookstoreOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookstoreOrder>> GetBookstoreOrder(int id)
        {
            var bookstoreOrder = await _context.BookstoreOrder.FindAsync(id);

            if (bookstoreOrder == null)
            {
                return NotFound();
            }

            return bookstoreOrder;
        }

        // PUT: api/BookstoreOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookstoreOrder(int id, BookstoreOrder bookstoreOrder)
        {
            if (id != bookstoreOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookstoreOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookstoreOrderExists(id))
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

        // POST: api/BookstoreOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookstoreOrder>> PostBookstoreOrder(BookstoreOrder bookstoreOrder)
        {
            _context.BookstoreOrder.Add(bookstoreOrder);
            await _context.SaveChangesAsync();

        //  return CreatedAtAction("GetBookstoreOrder", new { id = bookstoreOrder.Id }, bookstoreOrder);
            return CreatedAtAction(nameof(GetBookstoreOrder), new { id = bookstoreOrder.Id }, bookstoreOrder);
        }

        // DELETE: api/BookstoreOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookstoreOrder(int id)
        {
            var bookstoreOrder = await _context.BookstoreOrder.FindAsync(id);
            if (bookstoreOrder == null)
            {
                return NotFound();
            }

            _context.BookstoreOrder.Remove(bookstoreOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookstoreOrderExists(int id)
        {
            return _context.BookstoreOrder.Any(e => e.Id == id);
        }
    }
}
