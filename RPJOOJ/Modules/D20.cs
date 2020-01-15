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
            Random rnd = new Random();
            try
            {
                if (options == "")
                {
                    await ReplyAsync($"{Context.User.Mention} rolled: {(rnd.Next(1, 20).ToString())}");
                    return;
                }
                else
                {
                    var optionList = options.Split(" ").ToList();
                    int result = 0;
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
                                result += random;
                            }
                            break;
                        case "/":
                            result = random / numToBeOperated;
                            break;
                        default:
                            result = random;
                            break;
                    }

                    await ReplyAsync($"{Context.User.Mention} rolled: **{result.ToString()}**");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
