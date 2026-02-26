using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VitalLink.Constants;

namespace VitalLink.EntityFrameworkCore;

public class VitalLinkHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<VitalLinkDbContext>
{
    public VitalLinkDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        var builder = new DbContextOptionsBuilder<VitalLinkDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"),
                opts =>
                {
                    opts.UseNetTopologySuite();
                    opts.MigrationsHistoryTable("__EFMigrationsHistory", "public");
                });

        return new VitalLinkDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../host/VitalLink.HttpApi.Host"))
            .AddJsonFile(
                $"{MultiEnvironmentConstants.AspNetCoreEnvironmentAppSettingFile}{MultiEnvironmentConstants.AspNetCoreEnvironmentExtention}",
                optional: false)
            .AddJsonFile(
                $"{MultiEnvironmentConstants.AspNetCoreEnvironmentAppSettingFile}." +
                $"{Environment.GetEnvironmentVariable($"{MultiEnvironmentConstants.AspNetCoreEnvironment}")}" +
                $"{MultiEnvironmentConstants.AspNetCoreEnvironmentExtention}",
                true,
                true
            ).AddEnvironmentVariables();

        return builder.Build();
    }
}
