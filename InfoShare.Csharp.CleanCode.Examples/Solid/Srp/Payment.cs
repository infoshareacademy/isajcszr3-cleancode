using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Srp
{
	public class Payment
	{
		private readonly PaymentRequest _paymentRequest;

		public Guid Id { get; }
		public DateTime CreatedAt { get; }
		public int PaymentType { get; private set; }

		private readonly ICustomerAccountService _customerAccountService;
		private readonly IPaymentAuditService _paymentAuditService;
		private readonly IPaymentService _paymentService;

		public Payment(
			IPaymentService paymentService,
			ICustomerAccountService customerAccountService,
			IPaymentAuditService paymentAuditService)
		{
			_paymentService = paymentService;
			_customerAccountService = customerAccountService;
			_paymentAuditService = paymentAuditService;
		}

		public Payment(PaymentRequest paymentRequest)
		{
			_paymentRequest = paymentRequest;

			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
		}

		public static Payment Create(PaymentRequest paymentRequest)
		{
			return new Payment(paymentRequest);
		}

		public async Task Execute()
		{
			PaymentType = new PaymentTypeAdviser().GetTypeFor(_paymentRequest.Amount);

			var validator = new PaymentValidator(_customerAccountService);

			if (await validator.IsPaymentValid(_paymentRequest.SenderAccountNumber, _paymentRequest.Amount) == false)
			{
				throw new Exception();
			}

			if (PaymentType == 2)
			{
				await _paymentAuditService.LogForPostponedAudit(Id);
			}

			if (PaymentType == 3)
			{
				await _paymentAuditService.NotifyAboutAuditRequiredFor(Id);
			}

			var paymentResult = await _paymentService.StartPayment(
				_paymentRequest.SenderAccountNumber,
				_paymentRequest.RecipientAccountNumber,
				_paymentRequest.Amount);

			if (!paymentResult)
			{
				throw new Exception();
			}
		}
	}
}