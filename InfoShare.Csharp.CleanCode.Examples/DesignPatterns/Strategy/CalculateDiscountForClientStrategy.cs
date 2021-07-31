using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public class CalculateDiscountForClientStrategy : ICalculateDiscountStrategy
	{
		public async Task<decimal> Calculate(decimal amountToPay)
		{
			await Task.CompletedTask;

			return amountToPay;
		}
	}
}