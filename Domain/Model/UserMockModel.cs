namespace CSTechnicalChallenges.Domain.Model
{
	public class UserMockModel : IEquatable<UserMockModel>
	{
		#region Properties

		public string Name { get; set; }
		public int? Age { get; set; }

		#endregion

		#region Overrides

		public bool Equals(UserMockModel? other)
		{
			return Name == other!.Name && Age == other.Age;
		}

		public override int GetHashCode()
		{
			int hashAge = Age == null ? 0 : Age.GetHashCode();
			int hashName = Name == null ? 0 : Name.GetHashCode();

			return hashName ^ hashAge;
		}

		#endregion
	}
}
