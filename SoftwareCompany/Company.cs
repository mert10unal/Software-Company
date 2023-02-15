using System;
namespace SoftwareCompany
{
	public class Company
	{
		public int Id { get; set; }
		public string CompanyName { get; set; }
		public int TaxNumber { get; set; }
		public string Address { get; set; }
		public int CompanyDetailId { get; set; }

        public List<Worker> Workers { get; set; }
        public List<Contract> Contracts { get; set; }
		public CompanyDetail CompanyDetail { get; set; }
    }
}

