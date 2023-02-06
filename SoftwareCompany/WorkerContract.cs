using System;
namespace SoftwareCompany
{
	public class WorkerContract
	{
		public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ContractId { get; set; }

        public List<Worker> Workers { get; set; }
        public List<Contract> Contracts { get; set; }

    }

