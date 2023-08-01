namespace CSTechnicalChallenges.Domain.Interfaces
{
	public interface IListManager
	{
		/// <summary>
		/// Gerencia os objetos únicos de uma lista.
		/// </summary>
		/// <typeparam name="T">Genérico.</typeparam>
		/// <param name="elements">Lista de objetos de tipo genérico.</param>
		/// <returns>Lista com itens únicos.</returns>
		IList<T> ReturnOnlyUniqueObjects<T>(List<T> elements);
	}
}
