using System.Threading.Tasks;
using InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock;

namespace InfoShare.Csharp.CleanCode.Examples.Solid.Srp
{
	public class ContactInformation
	{
		public string CustomerAccountNumber { get; }
		public CustomerContactInfo ContactInfo { get; private set; }

		private ContactInformation(string customerAccountNumber)
		{
			CustomerAccountNumber = customerAccountNumber;
		}

		public static async Task<ContactInformation> GetFor(
			string customerAccountNumber,
			ICustomerContactService customerContactService)
		{
			return new ContactInformation(customerAccountNumber)
			{
				ContactInfo = await customerContactService.GetContactInfo(customerAccountNumber)
			};
		}
	}
}