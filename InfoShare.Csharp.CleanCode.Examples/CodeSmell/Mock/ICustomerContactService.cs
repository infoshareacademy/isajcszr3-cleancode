using System.Threading.Tasks;

namespace InfoShare.Csharp.CleanCode.Examples.CodeSmell.Mock
{
	public interface ICustomerContactService
	{
		Task<CustomerContactInfo> GetContactInfo(string customerAccountNumber);
	}

	public class CustomerContactService : ICustomerContactService
	{
		public Task<CustomerContactInfo> GetContactInfo(string customerAccountNumber)
		{
			return Task.FromResult(new CustomerContactInfo());
		}
	}
}