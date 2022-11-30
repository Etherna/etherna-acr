namespace Etherna.ACR.Middlewares.DebugPages
{
    public class DebugPagesOptions
    {
        public DebugPagesOptions()
        {
            ConfigurationPagePath = "/debug/config";
            ConfigurationPageTitle = "Configuration";

            RequestPagePath = "/debug/request";
            RequestPageTitle = "Request";
        }

        public string ConfigurationPagePath { get; set; }
        public string ConfigurationPageTitle { get; set; }
        public string RequestPagePath { get; set; }
        public string RequestPageTitle { get; set; }
    }
}
