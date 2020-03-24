using Discord.Commands;
using RPJOOJ.Utils;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class DCustom : ModuleBase<SocketCommandContext>
    {
        [Command("rolldcustom")]
        [Alias("custom")]
        [Summary("Creates a custom dice. Takes a custom number, operator and number as option parameters")]
        public async Task RollDCustomDice(string customDice, [Remainder]string options = "")
        {
            try
            {
                int result = 0, numberThatWillBeOperated = 0, random = 0;
                string resultMessage, mathOperator = string.Empty;
                string[] optionList = new string[] { };
                var rnd = new Random();

                if (!int.TryParse(customDice, out int customNumber))
                {
                    await ReplyAsync($"{Context.User.Mention}, you must inform me a valid number for me to create a dice.");
                    return;
                }

                if (options == "")
                {
                    resultMessage = Context.User.Mention.CreateMessageForRandomlyGeneratedNumber(customNumber);
                    await ReplyAsync(resultMessage);
                    return;
                }

                random = rnd.Next(1, customNumber);
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
