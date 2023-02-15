using System;
namespace SoftwareCompany
{
	public class CompanyDetail
	{
		public int Id { get; set; }
        public int CompanyId { get; set; }
		public int TaxNumber { get; set; }


        public Company Company { get; set; }
    }
}

