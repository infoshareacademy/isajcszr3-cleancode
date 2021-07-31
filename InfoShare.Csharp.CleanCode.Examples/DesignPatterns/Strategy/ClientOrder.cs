using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public class ClientOrder
	{
		public string OrderNumber { get; set; }
		public string ClientNumber { get; set; }
		public decimal OrderAmount { get; set; }

		public async Task<decimal> ApplyDiscount(ICalculateDiscountStrategy calculateDiscountStrategy)
		{
			return await calculateDiscountStrategy.Calculate(OrderAmount);
		}
	}
}