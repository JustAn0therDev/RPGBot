using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var rnd = new Random();
            string resultMessage;
            int result = 0;
            try
            {
                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 20)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }
                else
                {
                    var optionList = options.Split(" ").ToList();
                    int random = rnd.Next(1, 20);
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
