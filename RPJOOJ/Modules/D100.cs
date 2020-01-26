using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string resultMessage;
            var rnd = new Random();
            int result = 0;
            try
            {
                if (options == "")
                {
                    resultMessage = $"{Context.User.Mention} rolled: **{rnd.Next(1, 100)}**";
                    await ReplyAsync(resultMessage);
                    return;
                }
                else
                {
                    List<string> optionList = options.Split(" ").ToList();
                    int random = rnd.Next(1, 100);
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
                                result += rnd.Next(1, 100);
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
                await ReplyAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
