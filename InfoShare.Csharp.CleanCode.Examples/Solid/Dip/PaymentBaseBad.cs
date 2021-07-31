using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;
using InfoShare.Csharp.CleanCode.Examples.Solid.Ocp;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Dip
{
	public class PaymentBaseBad
	{
		private readonly PaymentRequest _paymentRequest;

		public Guid Id { get; }
		public DateTime CreatedAt { get; }
		public PaymentType PaymentType { get; }

		private readonly CustomerAccountService _customerAccountService;
		private readonly PaymentService _paymentService;

		public PaymentBaseBad(
			PaymentRequest paymentRequest,
			PaymentType paymentType)
		{
			_paymentRequest = paymentRequest;
			
			_paymentService = new PaymentService();
			_customerAccountService = new CustomerAccountService();

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