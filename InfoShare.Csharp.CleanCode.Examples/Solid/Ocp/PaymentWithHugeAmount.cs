using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
{
	public class PaymentWithHugeAmount : PaymentBase
	{
		private readonly IPaymentAuditService _paymentAuditService;

		public PaymentWithHugeAmount(
			PaymentRequest paymentRequest,
			IPaymentAuditService paymentAuditService,
			IPaymentService paymentService,
			ICustomerAccountService customerAccountService)
		: base(paymentRequest,
			PaymentType.HugeAmount,
			paymentService,
			customerAccountService)
		{
			_paymentAuditService = paymentAuditService;
		}

		public override Task RunAuditAction()
		{
			Console.WriteLine($"Audit called from {nameof(PaymentWithHugeAmount)} class");
			return _paymentAuditService.NotifyAboutAuditRequiredFor(Id);
		}
	}
}