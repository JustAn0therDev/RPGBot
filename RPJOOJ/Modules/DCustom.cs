using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class DCustom : ModuleBase<SocketCommandContext>
    {
        [Command("rolldcustom")]
        [Alias("custom")]
        [Summary("Creates a custom dice. Takes a custom number, operator and number as option parameters")]
        public async Task RollDCustomDice(string customDice = "", [Remainder]string options = "")
        {
            try
            {
                var rnd = new Random();
                string resultMessage;
                int customNumber = 0, result = 0, random = 0;
                string[] optionList = new string[] { };

                if (customDice == "")
                {
                    await ReplyAsync($"{Context.User.Mention}, you must inform me a number for me to create a dice.");
                    return;
                }

                customNumber = Convert.ToInt32(customDice);

                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, customNumber)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }

                optionList = options.Split(" ");
                int numToBeOperated = Convert.ToInt32(optionList[1]);
                random = rnd.Next(1, customNumber);

                switch (optionList[0])
                {
                    case "+":
                        result = random + numToBeOperated;
                        break;
                    case "-":
                        result = random - numToBeOperated;
                        break;
                    case "*":
                        for (int i = 0; i < numToBeOperated; i++)
                        {
                            result = rnd.Next(1, customNumber);
                        }
                        break;
                    case "/":
                        result = random / numToBeOperated;
                        break;
                    default:
                        result = random;
                        break;
                }

                resultMessage = $"{Context.User.Mention} rolled: **{result}**";

                await ReplyAsync(resultMessage);
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Sorry, something went wrong! Error: {ex.Message}");
            }
        }
    }
}
