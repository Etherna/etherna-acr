namespace Etherna.ACR.Middlewares.PrintConfigurationPage
{
    public class PrintConfigurationPageOptions
    {
        public PrintConfigurationPageOptions()
        {
            PagePath = "/debug/config";
            PageTitle = "Configuration print";
        }

        public string PagePath { get; set; }
        public string PageTitle { get; set; }
    }
}
