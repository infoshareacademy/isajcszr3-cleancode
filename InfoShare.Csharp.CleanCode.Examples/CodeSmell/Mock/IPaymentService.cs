using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock
{
	public interface IPaymentService
	{
		Task<bool> StartPayment(
			string senderAccountNumber,
			string recipientAccountNumber,
			decimal amount);
	}

	public class PaymentService : IPaymentService
	{
		public Task<bool> StartPayment(string senderAccountNumber, string recipientAccountNumber, decimal amount)
		{
			return Task.FromResult(true);
		}
	}
}