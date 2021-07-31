using System.Collections.Generic;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Factory
{
	public class Customer : ICustomer
	{
		public string Name { get; set; }
		public decimal DiscountPercentage => 0.1m;
		
		public Customer(string name)
		{
			Name = name;
		}

		public List<string> GetBenefits()
		{
			return new List<string>
			{
				"Discount"
			};
		}
	}
}