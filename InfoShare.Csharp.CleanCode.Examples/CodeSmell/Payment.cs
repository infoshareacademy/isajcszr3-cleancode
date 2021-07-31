using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell
{
	public class Payment
	{
		private readonly IPaymentService _paymentService;
		private readonly ICustomerAccountService _customerAccountService;
		private readonly ICustomerHistoryService _customerHistoryService;
		private readonly ICustomerContactService _customerContactService;
		private readonly IPaymentAuditService _paymentAuditService;

		private decimal amount;
		private int _type;
		private Guid _id;
		
		private DateTime createdAt;
		private DateTime executeAt;

		public string sender { get; set; }
		public string recipient { get; set; }

		public Payment(
			IPaymentService paymentService,
			ICustomerAccountService customerAccountService,
			ICustomerHistoryService customerHistoryService,
			ICustomerContactService customerContactService,
			IPaymentAuditService paymentAuditService)
		{
			_paymentService = paymentService;
			_customerAccountService = customerAccountService;
			_customerHistoryService = customerHistoryService;
			_customerContactService = customerContactService;
			_paymentAuditService = paymentAuditService;
		}

		public void Setup(string sNumber, string rNumber, decimal money, Guid id, DateTime date1, DateTime date2)
		{
			_id = id;
			amount = money;
			sender = sNumber;
			recipient = rNumber;
			createdAt = date1;
			executeAt = date2;
		}

		public async Task Run()
		{
			if (amount < 1000)
				_type = 1;
			else if (amount < 1000000)
				_type = 2;
			else
				_type = 3;

			if (await GetAccountBalance() < amount)
			{
				if (await CanPaymentBeCredited() == false)
				{
					if (await IsCustomerTrustworthy() == false)
					{
						throw new Exception();
					}
				}
			}

			if (_type == 3)
			{
				await NotifyAboutBigTransaction();
			}

			var r = await StartPayment();

			if (!r)
				throw new Exception();
		}

		public Task<decimal> GetAccountBalance()
		{
			return _customerAccountService.GetAccountBalance(sender);
		}

		public Task<bool> CanPaymentBeCredited()
		{
			return _customerAccountService.CanPaymentBeCredited(sender, amount);
		}

		public Task<bool> IsCustomerTrustworthy()
		{
			return _customerAccountService.IsCustomerTrustworthy(sender);
		}

		public Task NotifyAboutBigTransaction()
		{
			return _paymentAuditService.NotifyAboutAuditRequiredFor(_id);
		}

		public Task<bool> StartPayment()
		{
			return _paymentService.StartPayment(sender, recipient, amount);
		}

		public Task<List<PaymentHistory>> GetSenderPaymentHistory()
		{
			return _customerHistoryService.GetAccountPaymentHistory(sender, 10);
		}

		public Task<CustomerContactInfo> GetSenderContactInfo()
		{
			return _customerContactService.GetContactInfo(sender);
		}

		public Task<CustomerContactInfo> GetRecipientContactInfo()
		{
			return _customerContactService.GetContactInfo(recipient);
		}
	}
}