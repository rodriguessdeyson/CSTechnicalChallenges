using CSTechnicalChallenges.Domain.Interfaces;

namespace CSTechnicalChallenges.Services
{
	/// <summary>
	/// Permite a criação de um objeto do tipo ListManagerService para manipulação de lista.
	/// </summary>
	public class ListManagerService : IListManager
	{
		#region Constructor

		/// <summary>
		/// Inicializa um objeto do tipo ListManagerService.
		/// </summary>
		public ListManagerService()
		{
			
		}

		#endregion

		#region Methods

		public IList<T> ReturnOnlyUniqueObjects<T>(List<T> elements)
		{
			return elements.Distinct().ToList();
		}

		#endregion
	}
}
