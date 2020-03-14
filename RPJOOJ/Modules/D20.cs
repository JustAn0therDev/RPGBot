using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class D20 : ModuleBase<SocketCommandContext>
    {
        [Command("rolld20")]
        [Alias("D20")]
        [Summary("Rolls a D20 dice")]
        public async Task RollD20Dice([Remainder]string options = "")
        {
            try
            {
                string resultMessage = string.Empty;
                var rnd = new Random();
                int result = 0, numToBeOperated = 0, random = 0;
                string[] optionList = new string[] { };

                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 20)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }

                optionList = options.Split(" ");
                random = rnd.Next(1, 20);
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
                            result += rnd.Next(1, 20);
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
