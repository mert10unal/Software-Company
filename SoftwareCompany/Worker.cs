using System;
namespace SoftwareCompany
{
	public class Worker
	{
		public int Id { get; set; }
		public string IdentityNumber { get; set; }
		public double Salary { get; set; }
		public DateTime BirthofDate { get; set; }
		public int CompanyBoardId { get; set; }

		public CompanyBoard CompanyBoard { get; set; }
        public List<WorkerProject> WorkerProjects { get; set; }
        public List<WorkerContract> WorkerContracts { get; set; }
    }
}

