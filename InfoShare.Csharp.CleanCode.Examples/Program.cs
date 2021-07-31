using System;
using System.Threading.Tasks;
//using InfoShare.Csharp.CleanCode.Examples.Solid.Lsp;
using InfoShare.Csharp.CleanCode.Examples.DesignPatterns.Strategy;
namespace InfoShare.Csharp.CleanCode.Examples
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			//var liskovExample = new App();

			//await liskovExample.Run();
			var repositoryExample = new App();
			repositoryExample.Run();
		}
	}
}