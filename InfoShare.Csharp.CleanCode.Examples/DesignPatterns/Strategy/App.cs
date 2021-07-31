namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy
{
	public class App
	{
		public void Run()
		{
			var clientOrder = new ClientOrder
			{
				ClientNumber = "123",
				OrderNumber = "1",
				OrderAmount = 1000
			};
			
			var finalAmount =
				clientOrder.ApplyDiscount(new CalculateDiscountForClientStrategy());

			//but if client exceeded 10000 orders and became VIP we can apply bigger discount
			var finalAmountForVip =
				clientOrder.ApplyDiscount(new CalculateDiscountForVipStrategy());

			//or if client is distributor use totally different algorithm
			var finalAmountForDistributor =
				clientOrder.ApplyDiscount(new CalculateDiscountForDistributorStrategy());
		}
	}
}