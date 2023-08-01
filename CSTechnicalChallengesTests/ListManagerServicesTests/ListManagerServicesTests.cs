using CSTechnicalChallenges.Domain.Interfaces;
using CSTechnicalChallenges.Domain.Model;
using CSTechnicalChallenges.Services;
using Xunit;

namespace CSTechnicalChallengesTests.ListManagerServicesTests
{
	public class ListManagerServicesTests
	{
		[Theory]
		[MemberData(nameof(DataNumber))]
		private void CheckListOfNumbers(List<long> numbers, List<long> expected)
		{
			IListManager listManager = new ListManagerService();
			IList<long> result = listManager.ReturnOnlyUniqueObjects(numbers);

			Assert.Equal(expected, result);
		}

		[Theory]
		[MemberData(nameof(DataModel))]
		private void CheckListOfUsers(List<UserMockModel> model, List<UserMockModel> expected)
		{
			IListManager listManager = new ListManagerService();
			IList<UserMockModel> result = listManager.ReturnOnlyUniqueObjects(model);

			Assert.Equal(expected, result);
		}

		#region Extension

		public static IEnumerable<object[]> DataNumber()
		{
			yield return new object[] { new List<long> { 1, 2, 3, 2, 4, 5, 3, 6 }, new List<long> { 1, 2, 3, 4, 5, 6 } };
		}

		public static IEnumerable<object[]> DataModel()
		{
			yield return new object[]
			{
				new List<UserMockModel>()
				{
					new UserMockModel()
					{
						Name = "Gabriel",
						Age  = 35,
					},
					new UserMockModel()
					{
						Name = "Gabriel",
						Age  = 35,
					},
					new UserMockModel()
					{
						Name = "Paula",
						Age  = 25,
					},
					new UserMockModel()
					{
						Name = "Paula",
						Age  = 35,
					},
				},
				new List<UserMockModel>()
				{
					new UserMockModel()
					{
						Name = "Gabriel",
						Age  = 35,
					},
					new UserMockModel()
					{
						Name = "Paula",
						Age  = 25,
					},
					new UserMockModel()
					{
						Name = "Paula",
						Age  = 35,
					},
				},
			};
		}

		#endregion
	}
}
