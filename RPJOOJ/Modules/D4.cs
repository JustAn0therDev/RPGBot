using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class D4 : ModuleBase<SocketCommandContext>
    {
        [Command("rolld4")]
        [Alias("D4")]
        [Summary("Rolls a D4 dice.")]
        public async Task RollD4Dice([Remainder]string options = "")
        {
            try
            {
                string resultMessage = string.Empty;
                var rnd = new Random();
                int result = 0, numToBeOperated = 0, random = 0;
                string[] optionList = new string[] { };

                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 4)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }

                optionList = options.Split(" ");
                random = rnd.Next(1, 4);
                numToBeOperated = Convert.ToInt32(optionList[1]);

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
                            result += rnd.Next(1, 4);
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
