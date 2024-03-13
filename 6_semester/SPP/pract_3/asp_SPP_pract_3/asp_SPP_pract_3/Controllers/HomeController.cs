using asp_SPP_pract_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace asp_SPP_pract_3.Controllers
{
    [ApiController]
    [Route("/trains")]
    public class HomeController : ControllerBase
    {
        private readonly TrainContext _context;
        public HomeController(TrainContext  context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetTrains()
        {
            return await _context.Trains.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Train>> PostTrain(Train train)
        {
            _context.Trains.Add(train);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrains), new { id = train.TrainId }, train);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain(int id, Train train)
        {
            if (id != train.TrainId)
            {
                return BadRequest();
            }

            //_context.Entry(train).State = EntityState.Modified;
            //_context.Trains.Local[id].TrainId = train.TrainId;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            var train = await _context.Trains.FindAsync(id);

            if (train == null)
            {
                return NotFound();
            }

            _context.Trains.Remove(train);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
