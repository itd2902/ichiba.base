namespace IChiba.Core.Configuration
{
    public partial class IChibaConfig
    {
        public const string IChiba = "IChiba";

        /// <summary>
        /// Gets or sets a value indicating whether to display the full error in production environment.
        /// It's ignored (always enabled) in development environment
        /// </summary>
        public bool DisplayFullErrorStack { get; set; }
    }
}
