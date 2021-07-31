using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Srp
{
	public class PaymentValidator
	{
		private readonly ICustomerAccountService _customerAccountService;

		public PaymentValidator(ICustomerAccountService customerAccountService)
		{
			_customerAccountService = customerAccountService;
		}

		public async Task<bool> IsPaymentValid(string senderAccountNumber, decimal paymentAmount)
		{
			return 
				await _customerAccountService.GetAccountBalance(senderAccountNumber) < paymentAmount &&
				await _customerAccountService.CanPaymentBeCredited(senderAccountNumber, paymentAmount) == false &&
				await _customerAccountService.IsCustomerTrustworthy(senderAccountNumber);
		}
	}
}