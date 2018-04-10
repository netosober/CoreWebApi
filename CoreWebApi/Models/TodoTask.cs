namespace CoreWebApi.Models
{
	using System;

	public class TodoTask
	{
		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public DateTime? CreatedOn
		{
			get;
			set;
		}

		public DateTime? DueOn
		{
			get;
			set;
		}

		public DateTime? CompletedOn
		{
			get;
			set;
		}
	}
}
