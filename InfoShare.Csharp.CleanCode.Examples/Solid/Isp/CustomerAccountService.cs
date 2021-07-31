using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Isp
{
	public class CustomerAccountService : ICustomerInterfaceBad
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

		public Task<CustomerContactInfo> GetContactInfo(string customerAccountNumber)
		{
			throw new System.NotImplementedException();
		}

		public Task<List<PaymentHistory>> GetAccountPaymentHistory(string customerAccountNumber, int lastTransactionsCount)
		{
			throw new System.NotImplementedException();
		}
	}
}