using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VitalLink.Constants;
using VitalLink.Settings.Custom;
using VitalLink.Settings.Models;
using VitalLink.Settings.Models.Mail;

namespace VitalLink.Settings.Seeders;

public class MailSettingDefinitionSeeder : SettingDefinitionSeeder<MailSettingModel>
{
    private readonly IConfiguration _configuration;
    
    public MailSettingDefinitionSeeder(
        ICustomSettingManager<MailSettingModel> customSettingManager,
        IConfiguration configuration) : 
        base(customSettingManager)
    {
        _configuration = configuration;
    }

    public async Task SeedDataAsync()
    {
        var mailSettings = _configuration
            .GetSection(SettingConstants.MailSettingModel.Gmail)
            .Get<MailSettings>();
        
        if (mailSettings is null) return;
        
        var model = new MailSettingModel
        {
            Server = new SettingItem { Name = SettingConstants.MailSettingModel.Server, Value = mailSettings.Server },
            Port = new SettingItem { Name = SettingConstants.MailSettingModel.Port, Value = mailSettings.Port },
            Login = new SettingItem { Name = SettingConstants.MailSettingModel.Login, Value = mailSettings.Login },
            Key = new SettingItem { Name = SettingConstants.MailSettingModel.Key, Value = mailSettings.Key }
        };
        await SeedAsync(model);
    }
}