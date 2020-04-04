using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuncoastOverflow.Models;

namespace SuncoastOverflow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionsController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public QuestionsController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Questions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
    {
      return await _context.Questions.ToListAsync();
    }

    // GET: api/Questions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetQuestion(int id)
    {
      var question = await _context.Questions.FindAsync(id);

      if (question == null)
      {
        return NotFound();
      }

      return question;
    }

    // PUT: api/Questions/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestion(int id, Question question)
    {
      if (id != question.Id)
      {
        return BadRequest();
      }

      _context.Entry(question).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!QuestionExists(id))
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

    // POST: api/Questions
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<Question>> PostQuestion(Question question)
    {
      if (question.Title == null)
      {
        return BadRequest("Title required to submit question");
      }
      else if (question.Asked == null)
      {
        return BadRequest("You need to actually ask the question");
      }
      else
      {

        question.TimeSubmitted = DateTime.Now;
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        // return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        return Ok(question);
      }
    }

    [HttpPost("{questionId}/answers")]
    public async Task<ActionResult> AddAnswerForQuestion(int questionId, Answer answer)
    {
      //add questionId to answer
      answer.QuestionId = questionId;
      // add answer to the database
      _context.Answers.Add(answer);
      await _context.SaveChangesAsync();
      // return something
      return Ok(answer);
    }

    // DELETE: api/Questions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Question>> DeleteQuestion(int id)
    {
      var question = await _context.Questions.FindAsync(id);
      if (question == null)
      {
        return NotFound();
      }

      _context.Questions.Remove(question);
      await _context.SaveChangesAsync();

      return question;
    }

    private bool QuestionExists(int id)
    {
      return _context.Questions.Any(e => e.Id == id);
    }
  }
}
