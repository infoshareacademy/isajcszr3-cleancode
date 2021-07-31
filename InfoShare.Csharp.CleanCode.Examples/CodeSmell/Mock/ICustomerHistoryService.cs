using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock
{
	public interface ICustomerHistoryService
	{
		Task<List<PaymentHistory>> GetAccountPaymentHistory(string customerAccountNumber, int lastTransactionsCount);
	}

	public class CustomerHistoryService : ICustomerHistoryService
	{
		public Task<List<PaymentHistory>> GetAccountPaymentHistory(string customerAccountNumber, int lastTransactionsCount)
		{
			return Task.FromResult(new List<PaymentHistory>());
		}
	}

	public class PaymentHistory
	{
	}
}