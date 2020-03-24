using Discord.Commands;
using RPJOOJ.Utils;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class D100 : ModuleBase<SocketCommandContext>
    {
        [Command("rolld100")]
        [Alias("D100")]
        [Summary("Rolls a D100 dice.")]
        public async Task RollD100Dice([Remainder]string options = "")
        {
            try
            {
                int result = 0, numberThatWillBeOperated = 0, random = 0, diceNumber = 100;
                string resultMessage, mathOperator = string.Empty;
                string[] optionList = new string[] { };
                var rnd = new Random();

                if (options == "")
                {
                    resultMessage = Context.User.Mention.CreateMessageForRandomlyGeneratedNumber(diceNumber);
                    await ReplyAsync(resultMessage);
                    return;
                }

                random = rnd.Next(1, diceNumber);
                optionList = options.Split(" ");
                numberThatWillBeOperated = Convert.ToInt32(optionList[1]);

                (mathOperator, numberThatWillBeOperated) = GeneralUtilities.GetAllOptionsIntegersFromOptionList(optionList);

                result = GeneralUtilities.CalculateResultFromRequestedOperator(mathOperator, random, numberThatWillBeOperated);

                resultMessage = Context.User.Mention.CreateMessageForCalculatedResult(result);

                await ReplyAsync(resultMessage);
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Sorry, something went wrong! Error: {ex.Message}");
            }
        }
    }
}
