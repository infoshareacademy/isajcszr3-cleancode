using System;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Ocp
{
	public class PaymentRequest
	{
		public decimal Amount { get; }
		public DateTime ExecuteAt { get; }
		public string SenderAccountNumber { get; }
		public string RecipientAccountNumber { get; }

		public PaymentRequest(
			decimal amount,
			DateTime executeAt,
			string senderAccountNumber,
			string recipientAccountNumber)
		{
			Amount = amount;
			ExecuteAt = executeAt;
			SenderAccountNumber = senderAccountNumber;
			RecipientAccountNumber = recipientAccountNumber;
		}
	}
}