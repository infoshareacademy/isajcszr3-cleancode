using System.Runtime.InteropServices.ComTypes;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Factory
{
	public class App
	{
		public void Run()
		{
			var customer = CustomerFactory.CreateCustomer("John Doe", CustomerType.General);

			var customerVip = CustomerFactory.CreateCustomer("Ann Smith", CustomerType.Vip);

			customer.GetBenefits();
			customerVip.GetBenefits();
		}
	}
}