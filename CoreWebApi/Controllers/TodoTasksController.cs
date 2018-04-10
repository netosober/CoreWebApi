namespace CoreWebApi.Controllers
{
	using CoreWebApi.Models;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	[Produces("application/json")]
	[Route("api/TodoTasks")]
	public class TodoTasksController : Controller
	{
		private readonly ApiContext context;

		public TodoTasksController(
			ApiContext apiContext)
		{
			context = apiContext;
		}

		// GET: api/TodoTasks
		[HttpGet]
		public IEnumerable<TodoTask> GetTodoTask()
		{
			return context.TodoTask;
		}

		// GET: api/TodoTasks/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTodoTask(
			[FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			TodoTask todoTask =
				await context.TodoTask.SingleOrDefaultAsync(m => m.Id == id);

			if (todoTask == null)
			{
				return NotFound();
			}

			return Ok(todoTask);
		}

		// PUT: api/TodoTasks/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTodoTask(
			[FromRoute] int id,
			[FromBody] TodoTask todoTask)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != todoTask.Id)
			{
				return BadRequest();
			}

			context.Entry(todoTask).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TodoTaskExists(id))
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

		// POST: api/TodoTasks
		[HttpPost]
		public async Task<IActionResult> PostTodoTask(
			[FromBody] TodoTask todoTask)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			context.TodoTask.Add(todoTask);
			await context.SaveChangesAsync();

			return CreatedAtAction(
				"GetTodoTask",
				new {id = todoTask.Id},
				todoTask);
		}

		// DELETE: api/TodoTasks/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTodoTask(
			[FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			TodoTask todoTask =
				await context.TodoTask.SingleOrDefaultAsync(m => m.Id == id);
			if (todoTask == null)
			{
				return NotFound();
			}

			context.TodoTask.Remove(todoTask);
			await context.SaveChangesAsync();

			return Ok(todoTask);
		}

		private bool TodoTaskExists(
			int id)
		{
			return context.TodoTask.Any(e => e.Id == id);
		}
	}
}