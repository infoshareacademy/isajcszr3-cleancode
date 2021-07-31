using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public class CalculateDiscountForVipStrategy : ICalculateDiscountStrategy
	{
		public async Task<decimal> Calculate(decimal amountToPay)
		{
			await Task.CompletedTask;

			return amountToPay * 0.8m;
		}
	}
}