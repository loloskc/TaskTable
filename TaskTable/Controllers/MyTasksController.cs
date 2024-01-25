using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTable.Data;
using TaskTable.Models;

namespace TaskTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MyTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MyTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTask>>> GetMyTasks()
        {
            return await _context.MyTasks.ToListAsync();
        }

        // GET: api/MyTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTask>> GetMyTask(int id)
        {
            var myTask = await _context.MyTasks.FindAsync(id);

            if (myTask == null)
            {
                return NotFound();
            }

            return myTask;
        }

        // PUT: api/MyTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTask(int id, MyTask myTask)
        {
            if (id != myTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(myTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTaskExists(id))
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

        // POST: api/MyTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyTask>> PostMyTask(MyTask myTask)
        {
            _context.MyTasks.Add(myTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyTask", new { id = myTask.Id }, myTask);
        }

        // DELETE: api/MyTasks/5
        [HttpDelete("{id}")] 
        public async Task<ActionResult<MyTask>> DeleteMyTask(int id)
        {
            var myTask = await _context.MyTasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }

            _context.MyTasks.Remove(myTask);
            await _context.SaveChangesAsync();

            return myTask;
        }

        private bool MyTaskExists(int id)
        {
            return _context.MyTasks.Any(e => e.Id == id);
        }
    }
}
