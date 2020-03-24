using Discord;

namespace RPJOOJ.Factories
{
    public class EmbedBuilderFactory
    {
        public static EmbedBuilder CreateEmbedBuilder(string title, Color color, string description)
        {
            return new EmbedBuilder
            {
                Title = title,
                Color = color,
                Description = description
            };
        } 
    }
}
