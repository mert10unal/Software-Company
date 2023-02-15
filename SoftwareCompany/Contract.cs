using System;
namespace SoftwareCompany
{
	public class Contract
	{
		public int Id { get; set; }
		public float TotalCost { get; set; }
		public DateTime Deadline { get; set; }
		public int ProjectId { get; set; }
		public int CompanyId { get; set; }

        public List<WorkerContract> WorkersContracts { get; set; }
		public Project Project { get; set; }

    }
}

