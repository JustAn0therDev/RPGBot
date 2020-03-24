using Discord;
using Discord.Commands;

namespace RPJOOJ.Utils
{
    public static class EmbedBuilderExtensions
    {
        public static async void AppendModulesFromCommandServiceToEmbedBuilder(this EmbedBuilder embedBuilder, ICommandContext context, CommandService commandService)
        {
            foreach (var module in commandService.Modules)
            {
                string description = "";
                foreach (var cmd in module.Commands)
                {
                    var result = await cmd.CheckPreconditionsAsync(context);
                    if (result.IsSuccess)
                        description += $"${cmd.Aliases[0]}\n{cmd.Summary}";
                }

                if (!string.IsNullOrWhiteSpace(description))
                {
                    embedBuilder.AddField(x =>
                    {
                        x.Name = module.Name;
                        x.Value = description;
                        x.IsInline = false;
                    });
                }
            }
        }
    }
}
