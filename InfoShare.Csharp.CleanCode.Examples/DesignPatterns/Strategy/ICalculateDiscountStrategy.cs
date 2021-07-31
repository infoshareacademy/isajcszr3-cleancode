using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public interface ICalculateDiscountStrategy
	{
		Task<decimal> Calculate(decimal amountToPay);
	}
}