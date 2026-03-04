using System.Threading.Tasks;
using Volo.Abp.Data;

namespace VitalLink.Settings.Seeders;

public class GenericSettingSeeder : IGenericSettingSeeder
{
    //Add seeder services here.
    private readonly MailSettingDefinitionSeeder _mailSettingDefinitionSeeder;

    public GenericSettingSeeder(
        MailSettingDefinitionSeeder mailSettingDefinitionSeeder
    )
    {
        _mailSettingDefinitionSeeder = mailSettingDefinitionSeeder;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _mailSettingDefinitionSeeder.SeedDataAsync();
    }
}