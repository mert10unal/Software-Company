using System;
namespace SoftwareCompany
{
	public class CompanyBoard
	{
		public int Id { get; set; }
		public string CompanyName { get; set; }
		public int TaxNumber { get; set; }
		public string Address { get; set; }

		public List<Worker> Workers { get; set; }
    }
}

