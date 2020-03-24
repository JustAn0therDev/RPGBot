using System;

namespace RPJOOJ.Utils
{
    public class GeneralUtilities
    {
        public static (string, int) GetAllOptionsIntegersFromOptionList(string[] optionList)
        {
            return (optionList[0], Convert.ToInt32(optionList[1]));
        }

        public static int CalculateResultFromRequestedOperator(string mathOperator, int random, int numberThatWillBeOperated)
        {
            int result = 0;

            switch (mathOperator)
            {
                case "+":
                    result = random + numberThatWillBeOperated;
                    break;
                case "-":
                    result = random - numberThatWillBeOperated;
                    break;
                case "*":
                    for (int i = 0; i < numberThatWillBeOperated; i++)
                    {
                        result += random;
                    }
                    break;
                case "/":
                    result = random / numberThatWillBeOperated;
                    break;
                default:
                    result = random;
                    break;
            }

            return result;
        }
    }
}
