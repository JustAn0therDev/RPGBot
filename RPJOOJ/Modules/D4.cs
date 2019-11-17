using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Random rnd = new Random();
            int result;
            try
            {
                if (options == "")
                {
                    await ReplyAsync($"{Context.User.Mention} rolled: {(rnd.Next(1, 4).ToString())}");
                    return;
                }
                else
                {
                    List<string> optionList = options.Split(" ").ToList();
                    int random = rnd.Next(1, 4);
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
                            result = random * numToBeOperated;
                            break;
                        case "/":
                            result = random / numToBeOperated;
                            break;
                        default:
                            result = random;
                            break;
                    }

                    await ReplyAsync($"{Context.User.Mention} rolled: {result.ToString()} ({random}, {numToBeOperated})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
