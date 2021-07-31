namespace InfoShare.Csharp.CleanCode.Examples.Solid.Srp
{
	public class PaymentTypeAdviser
	{
		public int GetTypeFor(decimal paymentAmount)
		{
			if (paymentAmount < 1000)
				return 1;

			if (paymentAmount < 1000000)
				return 2;
			
			return 3;
		}
	}
}