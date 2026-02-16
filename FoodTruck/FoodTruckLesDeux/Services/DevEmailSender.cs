using Microsoft.AspNetCore.Identity.UI.Services;

namespace FoodTruckLesDeux.Services
{
    public class DevEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
