namespace InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Repository
{
	public class App
	{
		public void Run()
		{
			IClientRepository repository = new ClientRepositoryMock();

			var client = new Client("Coma", "cmp-coma.jpg");

			repository.Add(client);

			var clientFromRepo = repository.GetById(client.Id);

			repository.Remove(clientFromRepo.Id);
		}
	}
}