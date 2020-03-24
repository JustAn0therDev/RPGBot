using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using System;
using RPJOOJ.Utils;
using RPJOOJ.Factories;

namespace RPJOOJ.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        #region Private Props

        private readonly CommandService _service;

        #endregion

        #region Constructors

        public Help(CommandService service)
        {
            _service = service;
        }

        #endregion

        #region Public Methods

        [Command("help")]
        [Alias("help")]
        [Summary("Returns a list containing all of RPJOOJ's commands. All dice commands can take an operator and number as optional parameters!")]
        public async Task GetHelpAsync()
        {
            try
            {
                var builder = EmbedBuilderFactory.CreateEmbedBuilder("All of the commands!", Color.Red, "These are the available commands:");

                builder.AppendModulesFromCommandServiceToEmbedBuilder(Context, _service);

                await ReplyAsync("", false, builder.Build());
            }
            catch (Exception ex)
            {
                await ReplyAsync($"Sorry, something went wrong! Error: {ex.Message}");
            }
        }

        #endregion
    }
}

