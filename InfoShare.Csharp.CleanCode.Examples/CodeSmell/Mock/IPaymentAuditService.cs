using System;
using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock
{
	public interface IPaymentAuditService
	{
		Task NotifyAboutAuditRequiredFor(Guid transactionId);

		Task LogForPostponedAudit(Guid transactionId);
	}

	public class PaymentAuditService : IPaymentAuditService
	{
		public Task NotifyAboutAuditRequiredFor(Guid transactionId)
		{
			return Task.CompletedTask;
		}

		public Task LogForPostponedAudit(Guid transactionId)
		{
			return Task.CompletedTask;
		}
	}
}