using System;

namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Repository
{
	public class Client
	{
		public Client()
		{
			Id = Guid.NewGuid();
		}

		public Client(Guid id)
		{
			Id = id;
		}

		public Client(string name, string logo)
			: this()
		{
			Name = name;
			Logo = logo;
		}

		public Guid Id { get; }
		public string Name { get; set; }
		public string Logo { get; set; }
	}
}