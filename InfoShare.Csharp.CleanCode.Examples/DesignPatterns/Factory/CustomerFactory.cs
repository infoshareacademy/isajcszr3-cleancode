namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Factory
{
	public static class CustomerFactory
	{
		public static ICustomer CreateCustomer(string name, CustomerType customerType)
		{
			switch (customerType)
			{
				case CustomerType.General:
					return new Customer(name);
				case CustomerType.Vip:
					return new CustomerVip(name);
			}

			return new Customer(name);
		}
	}

	public enum CustomerType
	{
		General,
		Vip
	}
}