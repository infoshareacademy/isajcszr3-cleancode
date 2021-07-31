using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Isp
{
	public interface ICustomerInterfaceBad
	{
		Task<decimal> GetAccountBalance(string customerAccountNumber);
		Task<bool> CanPaymentBeCredited(string customerAccountNumber, decimal paymentAmount);
		Task<bool> IsCustomerTrustworthy(string customerAccountNumber);
		Task<CustomerContactInfo> GetContactInfo(string customerAccountNumber);
		Task<List<PaymentHistory>> GetAccountPaymentHistory(string customerAccountNumber, int lastTransactionsCount);
	}
}