using DnD_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterContext _context;

        public CharactersController(CharacterContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.Include(c => c.CharacterStats).ToListAsync();
        }

        // GET: api/Characters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(long id)
        {
            var character = await _context.Characters.Include(c => c.CharacterStats).FirstAsync(c => c.CharacterId == id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(long id, Character character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;
            _context.Entry(character.CharacterStats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.CharacterId }, character);
        }

        // DELETE: api/Characters/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(long id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return character;
        }

        private bool CharacterExists(long id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
