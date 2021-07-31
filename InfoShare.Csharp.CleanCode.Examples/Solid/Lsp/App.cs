using System;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;
using InfoShare.Csharp.CleanCode.Examples.Solid.Ocp;
using NSubstitute;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Lsp
{
	public class App
	{
		public async Task Run()
		{
			var paymentBase = new PaymentBase(
				new PaymentRequest(
					new Random().Next(100),
					DateTime.UtcNow,
					Guid.NewGuid().ToString(),
					Guid.NewGuid().ToString()),
				PaymentType.Simple,
				new PaymentService(),
				new CustomerAccountService());

			await paymentBase.Execute();

			PaymentBase paymentBase2 = new PaymentWithLargeAmount(
				new PaymentRequest(
					new Random().Next(100),
					DateTime.UtcNow,
					Guid.NewGuid().ToString(),
					Guid.NewGuid().ToString()),
				new PaymentAuditService(),
				new PaymentService(),
				new CustomerAccountService());

			await paymentBase2.Execute();
		}
	}
}