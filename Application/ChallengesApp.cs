using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Domain.Model;

namespace CSTechnicalChallenges.Application
{
	/// <summary>
	/// Permite a criação de um objeto do tipo ChallengesApp para execução dos desafios.
	/// </summary>
	public class ChallengesApp
	{
		private readonly INumberService NumberService;
		private readonly IListManager ListManagerService;

		#region Constructor

		/// <summary>
		/// Inicializa um objeto do tipo ChallengesApp.
		/// </summary>
		/// <param name="numberService">Injeção de dependência para o serviço numérico.</param>
		/// <param name="listManagerService">Injeção de dependência para o serviço de lista.</param>
		public ChallengesApp(INumberService numberService, IListManager listManagerService)
		{
			NumberService = numberService;
			ListManagerService = listManagerService;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Executa toda a aplicação.
		/// </summary>
		public void Run()
		{
			Console.WriteLine("Desafio 1:");
			FirstChallenge();

			Console.WriteLine("Desafio 2:");
			SecondChallenge();

			Console.WriteLine("Desafio 3:");
			ThirdChallenge();

			Console.WriteLine("Desafio 3:");
			FourthChallenge();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Executa o desafio 1.
		/// </summary>
		private void FirstChallenge()
		{
			long testNumber = 458;
			Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");

			testNumber = 658;
			Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");

			testNumber = 9999999;
			Console.WriteLine($"A representação por extenso do número {testNumber} é: {NumberService.ToWords(testNumber)}");
		}

		/// <summary>
		/// Executa o desafio 2.
		/// </summary>
		private void SecondChallenge()
		{
			long[] nums = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
			Console.WriteLine($"A soma de {nums.Length} números inteiros é: {NumberService.Sum(nums)}");

			nums = Enumerable.Range(0, 1000000).Select(el => (long)el).ToArray();
			Console.WriteLine($"A soma de {nums.Length} números inteiros é: {NumberService.Sum(nums)}");
		}

		/// <summary>
		/// Executa o desafio 3.
		/// </summary>
		private void ThirdChallenge()
		{
			string mathExpression = string.Empty;
			try
			{
				mathExpression = "2 + 3 * 5";

				long resolution = NumberService.ProcessMathExpression(mathExpression);
				Console.WriteLine($"A solução da expressão {mathExpression} é: {resolution}");

				mathExpression = "2 + 3 / 0";

				resolution = NumberService.ProcessMathExpression(mathExpression);
				Console.WriteLine($"A solução da expressão {mathExpression} é: {resolution}");
			}
			catch (Exception exception)
			{
				Console.WriteLine($"A solução da expressão {mathExpression} retornou um erro: {exception.Message}");
			}
		}

		/// <summary>
		/// Executa o desafio 4.
		/// </summary>
		private void FourthChallenge()
		{
			// Lista de objetos mocking.
			UserMockModel drUser = new()
			{
				Name = "Deyson Rodrigues",
				Age = 28,
			};
			UserMockModel pfUser = new()
			{
				Name = "Pedro Fernandes",
				Age = 25,
			};
			UserMockModel plUser = new()
			{
				Name = "Pedro Fernandes",
				Age = 25,
			};
			UserMockModel cUser = new()
			{
				Name = "Carla",
				Age = 25,
			};
			List<UserMockModel> users = new()
			{
				drUser, pfUser, plUser, cUser
			};

			List<UserMockModel> listWithUniqueItems = ListManagerService
				.ReturnOnlyUniqueObjects( users )
				.ToList();

			Console.WriteLine("Os elementos únicos na lista são: ");
			listWithUniqueItems.ForEach(item => Console.WriteLine($"Nome: {item.Name}, Idade: {item.Age}."));
		}

		#endregion
	}
}
