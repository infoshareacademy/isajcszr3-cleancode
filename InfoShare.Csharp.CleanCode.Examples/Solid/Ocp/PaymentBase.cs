using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
{
	public class PaymentBase
	{
		private readonly PaymentRequest _paymentRequest;

		public Guid Id { get; }
		public DateTime CreatedAt { get; }
		public PaymentType PaymentType { get; }

		private readonly ICustomerAccountService _customerAccountService;
		private readonly IPaymentService _paymentService;

		public PaymentBase(
			PaymentRequest paymentRequest,
			PaymentType paymentType,
			IPaymentService paymentService,
			ICustomerAccountService customerAccountService)
		{
			_paymentRequest = paymentRequest;
			_paymentService = paymentService;
			_customerAccountService = customerAccountService;

			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
			PaymentType = paymentType;
		}

		public async Task Execute()
		{
			var validator = new PaymentValidator(_customerAccountService);

			if (await validator.IsPaymentValid(_paymentRequest.SenderAccountNumber, _paymentRequest.Amount) == false)
			{
				throw new Exception();
			}

			await RunAuditAction();

			var paymentResult = await _paymentService.StartPayment(
				_paymentRequest.SenderAccountNumber,
				_paymentRequest.RecipientAccountNumber,
				_paymentRequest.Amount);

			if (!paymentResult)
			{
				throw new Exception();
			}
		}

		public virtual Task RunAuditAction()
		{
			Console.WriteLine($"Audit called from {nameof(PaymentBase)} class");
			return Task.CompletedTask;
		}
	}
}