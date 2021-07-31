using System.Collections.Generic;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Factory
{
	public interface ICustomer
	{
		public string Name { get; }

		public decimal DiscountPercentage { get; }

		public List<string> GetBenefits();
	}
}