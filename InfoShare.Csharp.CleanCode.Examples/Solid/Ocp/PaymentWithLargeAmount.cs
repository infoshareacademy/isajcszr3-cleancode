using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
{
	public class PaymentWithLargeAmount : PaymentBase
	{
		private readonly IPaymentAuditService _paymentAuditService;

		public PaymentWithLargeAmount(
			PaymentRequest paymentRequest,
			IPaymentAuditService paymentAuditService,
			IPaymentService paymentService,
			ICustomerAccountService customerAccountService)
		: base(paymentRequest,
			PaymentType.LargeAmount,
			paymentService,
			customerAccountService)
		{
			_paymentAuditService = paymentAuditService;
		}

		public override Task RunAuditAction()
		{
			Console.WriteLine($"Audit called from {nameof(PaymentWithLargeAmount)} class");
			return _paymentAuditService.LogForPostponedAudit(Id);
		}
	}
}