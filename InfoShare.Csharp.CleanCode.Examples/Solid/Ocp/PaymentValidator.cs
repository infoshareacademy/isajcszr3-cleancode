using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
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
			//return await Task.FromResult(true);
			return
				await _customerAccountService.GetAccountBalance(senderAccountNumber) >= paymentAmount &&
				await _customerAccountService.CanPaymentBeCredited(senderAccountNumber, paymentAmount) &&
				await _customerAccountService.IsCustomerTrustworthy(senderAccountNumber);
		}
	}
}