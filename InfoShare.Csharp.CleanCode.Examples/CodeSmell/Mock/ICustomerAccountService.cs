using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock
{
	public interface ICustomerAccountService
	{
		Task<decimal> GetAccountBalance(string customerAccountNumber);

		Task<bool> CanPaymentBeCredited(string customerAccountNumber, decimal paymentAmount);

		Task<bool> IsCustomerTrustworthy(string customerAccountNumber);
	}

	public class CustomerAccountService : ICustomerAccountService
	{
		public Task<decimal> GetAccountBalance(string customerAccountNumber)
		{
			return Task.FromResult(10000000m);
		}

		public Task<bool> CanPaymentBeCredited(string customerAccountNumber, decimal paymentAmount)
		{
			return Task.FromResult(true);
		}

		public Task<bool> IsCustomerTrustworthy(string customerAccountNumber)
		{
			return Task.FromResult(true);
		}
	}
}