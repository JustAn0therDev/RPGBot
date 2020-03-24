using System;

namespace RPJOOJ.Utils
{
    public static class GeneralExtensions
    {
        public static string CreateMessageForRandomlyGeneratedNumber(this string discordUser, int limitToGenerateRandomNumber)
        {
            var rnd = new Random();
            return $"{discordUser} rolled: **{rnd.Next(1, limitToGenerateRandomNumber)}**";
        }

        public static string CreateMessageForCalculatedResult(this string discordUser, int result)
        {
            return $"{discordUser} rolled: **{result}**";
        }
    }
}
