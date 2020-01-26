using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class D8 : ModuleBase<SocketCommandContext>
    {
        [Command("rolld8")]
        [Alias("D8")]
        [Summary("Rolls a D8 dice")]
        public async Task RollD8Dice([Remainder]string options = "")
        {
            var rnd = new Random();
            string resultMessage;
            int result = 0;
            try
            {
                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 8)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }
                else
                {
                    List<string> optionList = options.Split(" ").ToList();
                    int random = rnd.Next(1, 8);
                    int numToBeOperated = Convert.ToInt32(optionList[1]);
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
                                result += rnd.Next(1, 8);
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
                }
                await ReplyAsync(resultMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
