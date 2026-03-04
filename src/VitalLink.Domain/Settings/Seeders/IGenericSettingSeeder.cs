using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace VitalLink.Settings.Seeders;

public interface IGenericSettingSeeder : IDataSeedContributor,ITransientDependency
{
}