namespace Etherna.SSL.Settings
{
    public class EmailSettings
    {
        public enum EmailService
        {
            Sendgrid,
            Mailtrap,
            FakeSender
        }

        public EmailService CurrentService { get; set; } = EmailService.FakeSender;
        public string DisplayName { get; set; } = default!;
        public string SendingAddress { get; set; } = default!;
        public string ServiceKey { get; set; } = default!;
        public string? ServiceUser { get; set; }
    }
}
