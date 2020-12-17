namespace IChiba.Core.Configuration
{
    public partial class SSOConfig
    {
        public const string SSO = "SSO";

        public string Authority { get; set; }

        public string ApiName { get; set; }

        public bool RequireHttpsMetadata { get; set; }
    }
}
