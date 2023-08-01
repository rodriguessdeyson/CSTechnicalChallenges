using CSTechnicalChallenges.Domain;
using CSTechnicalChallenges.Domain.Helper;
using CSTechnicalChallenges.Domain.Interfaces;

namespace CSTechnicalChallenges.Services
{
	/// <summary>
	/// Permite a criação de um objeto do tipo NumberService para manipulação de dados numéricos.
	/// </summary>
	public class NumberService : INumberService
	{
        #region Attributes

        private readonly string[] Units =
        {
            "zero",
			"um",
			"dois",
			"três",
			"quatro",
			"cinco",
			"seis",
			"sete",
			"oito",
			"nove",
			"dez",
            "onze",
			"doze",
			"treze",
			"catorze",
			"quinze",
			"dezesseis",
			"dezessete",
			"dezoito",
			"dezenove"
        };

        private readonly string[] Dozens =
        {
            "", "",
			"vinte",
			"trinta",
			"quarenta",
			"cinquenta",
			"sessenta",
			"setenta",
			"oitenta",
			"noventa"
        };

        private readonly string[] Hundreds =
        {
            "",
			"cento",
			"duzentos",
			"trezentos",
			"quatrocentos",
			"quinhentos",
			"seiscentos",
			"setecentos",
			"oitocentos",
			"novecentos"
        };

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa um objeto do tipo NumberService.
        /// </summary>
        public NumberService()
		{
			
		}

		#endregion

		#region Methods

		public long ProcessMathExpression(string mathExpression)
		{
			List<string> postfixTokens = ShuntingYardHelper.ConvertToPostfix(mathExpression);
			return ShuntingYardHelper.CalculatePostfix(postfixTokens);
		}

		public long Sum(long[] numbersToSum)
		{
			return numbersToSum.Sum();
		}

		public string ToWords(long number)
		{
			if (number == 0)
				return Units[0];

			if (number < 0)
				return "menos " + ToWords(-number);

			string words = "";

			if ((number / 1000000) > 0)
			{
				if (number / 1000000 > 1)
					words += ToWords(number / 1000000) + " milhões ";
				else
					words += ToWords(number / 1000000) + " milhão ";
				number %= 1000000;
			}

			if ((number / 1000) > 0)
			{
				words += ToWords(number / 1000) + " mil ";
				number %= 1000;
			}

			if ((number / 100) > 0)
			{
				if (number == 100)
				{
					words += " cem ";
				}
				else
				{
					words += Hundreds[number / 100] + " ";
				}
				number %= 100;
			}

			if (number > 0)
			{
				if (words != "")
					words += "e ";
				
				if (number < 20)
					words += Units[number];
				else
				{
					words += Dozens[number / 10];
					if ((number % 10) > 0)
						words += " e " + Units[number % 10];
				}
			}

			return words.TrimEnd();
		}

		#endregion
	}
}
