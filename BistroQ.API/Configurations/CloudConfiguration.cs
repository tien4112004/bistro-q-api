using System.Text.Json;
using Amazon;
using Amazon.CloudFront;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
using BistroQ.Core.Common.Settings;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Services.Services;

namespace BistroQ.API.Configurations;

public static class CloudConfiguration
{
    public static IServiceCollection AddAwsS3Config(this IServiceCollection services)
    {
        var awsSettings = new AwsSettings().ReadFromEnvironment();
        var awsOptions = new AWSOptions
        {
            Credentials = new BasicAWSCredentials(
                awsSettings.AccessKey,
                awsSettings.SecretKey),
            Region = RegionEndpoint.GetBySystemName(awsSettings.Region)
        };
        services.AddDefaultAWSOptions(awsOptions);

        services.AddAWSService<IAmazonCloudFront>();
        services.AddAWSService<IAmazonS3>();
        
        services.AddSingleton(awsSettings);
        services.AddScoped<ICloudStorageService, AwsStorageService>();
        
        return services;
    }
}