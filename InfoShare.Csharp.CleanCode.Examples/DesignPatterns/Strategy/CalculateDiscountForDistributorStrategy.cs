using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public class CalculateDiscountForDistributorStrategy : ICalculateDiscountStrategy
	{
		public async Task<decimal> Calculate(decimal amountToPay)
		{
			await Task.CompletedTask;

			if (amountToPay > 1000000)
				return amountToPay * 0.7m;

			if (amountToPay > 100000)
				return amountToPay * 0.8m;

			return amountToPay * 0.9m;
		}
	}
}