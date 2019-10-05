using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quizBackEnd;
using quizBackEnd.Models;

namespace quizBackEnd.Controllers
{
    [Route("api/Quizzes")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuizzesController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [HttpGet]
        public IEnumerable<Quiz> GetQuiz()
        {
            return _context.Quiz;
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var quiz = await _context.Quiz.SingleOrDefaultAsync(m => m.ID == id);

                if (quiz == null)
                {
                    return NotFound();
                }

                return Ok(quiz);
            }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz([FromRoute] int id, [FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiz.ID)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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
        [Authorize] 
        [HttpPost]
        public async Task<IActionResult> PostQuiz([FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quiz.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.ID }, quiz);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quiz = await _context.Quiz.SingleOrDefaultAsync(m => m.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.ID == id);
        }
    

    // PUT: api/Quizzes/5
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
    //{
    //    if (id != quiz.ID)
    //    {
    //        return BadRequest();
    //    }
    //
    //    _context.Entry(quiz).State = EntityState.Modified;
    //
    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!QuizExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }
    //
    //    return NoContent();
    //}

    // POST: api/Quizzes
    //[HttpPost]
    //public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
    //{
    //    _context.Quiz.Add(quiz);
    //    await _context.SaveChangesAsync();
    //
    //    return CreatedAtAction("GetQuiz", new { id = quiz.ID }, quiz);
    //}
    //
    //// DELETE: api/Quizzes/5
    //[HttpDelete("{id}")]
    //public async Task<ActionResult<Quiz>> DeleteQuiz(int id)
    //{
    //    var quiz = await _context.Quiz.FindAsync(id);
    //    if (quiz == null)
    //    {
    //        return NotFound();
    //    }
    //
    //    _context.Quiz.Remove(quiz);
    //    await _context.SaveChangesAsync();
    //
    //    return quiz;
    //}
    //
    //private bool QuizExists(int id)
    //{
    //    return _context.Quiz.Any(e => e.ID == id);
    //}
}
}