using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExempEAP.Entity;
using ExempEAP.Models;
using Microsoft.AspNetCore.Cors;

namespace ExempEAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExesController : ControllerBase
    {
        private readonly ExempEAPContext _context;

        public CurrencyExesController(ExempEAPContext context)
        {
            _context = context;
        }

        // GET: api/CurrencyExes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyEx>>> GetCurrencyEx()
        {
            return await _context.CurrencyEx.ToListAsync();
        }
        
        // GET: api/CurrencyExes/5
        [HttpGet("{id}")]
        [EnableCors(PolicyName = "AllowAll")]
        public async Task<ActionResult<CurrencyEx>> GetCurrencyEx(long id)
        {
            var currencyEx = await _context.CurrencyEx.FindAsync(id);

            if (currencyEx == null)
            {
                return NotFound();
            }

            return currencyEx;
        }

        // PUT: api/CurrencyExes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencyEx(long id, CurrencyEx currencyEx)
        {
            if (id != currencyEx.Id)
            {
                return BadRequest();
            }

            _context.Entry(currencyEx).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExExists(id))
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

        // POST: api/CurrencyExes
        [HttpPost]
        public async Task<ActionResult<CurrencyEx>> PostCurrencyEx(CurrencyEx currencyEx)
        {
            _context.CurrencyEx.Add(currencyEx);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencyEx", new { id = currencyEx.Id }, currencyEx);
        }

        // DELETE: api/CurrencyExes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrencyEx>> DeleteCurrencyEx(long id)
        {
            var currencyEx = await _context.CurrencyEx.FindAsync(id);
            if (currencyEx == null)
            {
                return NotFound();
            }

            _context.CurrencyEx.Remove(currencyEx);
            await _context.SaveChangesAsync();

            return currencyEx;
        }

        private bool CurrencyExExists(long id)
        {
            return _context.CurrencyEx.Any(e => e.Id == id);
        }
    }
}
