using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class D50 : ModuleBase<SocketCommandContext>
    {
        [Command("rolld50")]
        [Alias("D50")]
        [Summary("Rolls a D50 dice.")]
        public async Task RollD50Dice([Remainder]string options = "")
        {
            try
            {
                string resultMessage = string.Empty;
                var rnd = new Random();
                int result = 0, numToBeOperated = 0, random = 0;
                string[] optionList = new string[] { };

                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 50)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }

                optionList = options.Split(" ");
                random = rnd.Next(1, 50);
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
                            result += rnd.Next(1, 50);
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
