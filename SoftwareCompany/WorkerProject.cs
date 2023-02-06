using System;
namespace SoftwareCompany
{
	public class WorkerProject
	{
		public int Id { get; set; }
		public int WorkerId { get; set; }
		public int ProjectId { get; set; }

		public Worker Worker { get; set; }
		public Project Project { get; set; }
    }
}

