using Microsoft.Extensions.Configuration;

namespace Domain
{
    public interface IEmailConfig
    {
        string From { get; }
    }

    public class EmailConfig : IEmailConfig
    {
        private readonly IConfiguration configuration;

        public EmailConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string From => this.configuration["from"];
    }
}
