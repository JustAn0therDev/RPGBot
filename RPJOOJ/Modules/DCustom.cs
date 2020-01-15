using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPJOOJ.Modules
{
    public class DCustom : ModuleBase<SocketCommandContext>
    {
        [Command("rolldcustom")]
        [Alias("custom")]
        [Summary("Creates a custom dice. Takes a custom number, operator and number as option parameters")]
        public async Task RollDCustomDice(string customDice = "",[Remainder]string options = "")
        {
            Random rnd = new Random();
            try
            {
                if (customDice == "")
                {
                    await ReplyAsync("You must inform me a number for me to create a dice.");
                    return;
                }
                int customNumber = Convert.ToInt32(customDice);

                if (options == "")
                {
                    await ReplyAsync($"{Context.User.Mention} rolled: {(rnd.Next(1, customNumber).ToString())}");
                    return;
                }
                else
                {
                    List<string> optionList = options.Split(" ").ToList();
                    int result = 0;
                    int random = rnd.Next(1, customNumber);
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
