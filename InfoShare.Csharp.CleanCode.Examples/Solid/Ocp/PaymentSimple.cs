using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;
using NSubstitute;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
{
	public class PaymentSimple : PaymentBase
	{
		public PaymentSimple(PaymentRequest paymentRequest)
		: base(paymentRequest,
			PaymentType.Simple,
			Substitute.For<IPaymentService>(),
			Substitute.For<ICustomerAccountService>())
		{
		}
	}
}