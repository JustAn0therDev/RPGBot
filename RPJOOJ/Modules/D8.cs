﻿using Discord.Commands;
using RPJOOJ.Utils;
using System;
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
            try
            {
                int result = 0, numberThatWillBeOperated = 0, random = 0, diceNumber = 8;
                string resultMessage, mathOperator = string.Empty;
                string[] optionList = new string[] { };
                var rnd = new Random();

                if (options == "")
                {
                    resultMessage = Context.User.Mention.CreateMessageForRandomlyGeneratedNumber(diceNumber);
                    await ReplyAsync(resultMessage);
                    return;
                }

                random = rnd.Next(1, diceNumber);
                optionList = options.Split(" ");
                numberThatWillBeOperated = Convert.ToInt32(optionList[1]);

                (mathOperator, numberThatWillBeOperated) = GeneralUtilities.GetAllOptionsIntegersFromOptionList(optionList);

                result = GeneralUtilities.CalculateResultFromRequestedOperator(mathOperator, random, numberThatWillBeOperated);

                resultMessage = Context.User.Mention.CreateMessageForCalculatedResult(result);

                await ReplyAsync(resultMessage);
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Sorry, something went wrong! Error: {ex.Message}");
            }
        }
    }
}
