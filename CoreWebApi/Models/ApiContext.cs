namespace CoreWebApi.Models
{
	using Microsoft.EntityFrameworkCore;

	public class ApiContext: DbContext
	{
		public ApiContext(
			DbContextOptions<ApiContext> options) : base(options)
		{

		}

		public DbSet<TodoTask> TodoTask
		{
			get;
			set;
		}
	}
}
