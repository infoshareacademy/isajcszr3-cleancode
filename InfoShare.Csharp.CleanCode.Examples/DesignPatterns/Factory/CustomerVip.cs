using System.Collections.Generic;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Factory
{
	public class CustomerVip : ICustomer
	{
		public string Name { get; }
		public decimal DiscountPercentage => 0.3m;

		public CustomerVip(string name)
		{
			Name = name;
		}

		public List<string> GetBenefits()
		{
			return new List<string>
			{
				"Insurance",
				"Cinema tickets",
				"Voucher for something",
			};
		}
	}
}