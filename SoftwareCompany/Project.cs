using System;
namespace SoftwareCompany
{
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ProjectCode { get; set; }
		public int ContractId { get; set; }

        public List<Project> Projects { get; set; }
		public Contract Contract { get; set; }
    }
}

