using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_esteban.Models.DataModels;
using Api_esteban.DataAccess;


namespace Api_esteban.Controllers
{
    [Route("api/[controller]")] //Controller for Request to Localhost:7190/api/Users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public UsersController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if (_context.Users == null){
                return  NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{Email}")]
        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FindAsync(email);
            
          //var userRequest = await Services.SearchByEmail(email);
            
          return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'UnivesityDBContext.User'  is null.");
          }
          _context.Users.Add(user);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(user => user.Id == id)).GetValueOrDefault();
        }
    }
}
