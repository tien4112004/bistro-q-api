using BistroQ.Core.Interfaces;

namespace BistroQ.Core.Common.Settings;

public class AwsSettings 
{
    public string AccessKey { get; set; } = null!;

    public string SecretKey { get; set; } = null!;

    public string BucketName { get; set; } = null!;

    public string Region { get; set; } = null!;
    
    public string CloudFrontDomain { get; set; } = null!;
    
    public string PrivateKey { get; set; } = null!;
    
    public string KeyPairId { get; set; } = null!;
    
    public AwsSettings ReadFromEnvironment()
    {
        AccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY") ?? throw new ArgumentNullException("AWS_ACCESS_KEY");
        SecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY") ?? throw new ArgumentNullException("AWS_SECRET_KEY");
        BucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME") ?? throw new ArgumentNullException("AWS_BUCKET_NAME");
        Region = Environment.GetEnvironmentVariable("AWS_REGION") ?? throw new ArgumentNullException("AWS_REGION");
        CloudFrontDomain = Environment.GetEnvironmentVariable("AWS_CLOUDFRONT_DOMAIN") ?? throw new ArgumentNullException("AWS_CLOUDFRONT_DOMAIN");
        KeyPairId = Environment.GetEnvironmentVariable("AWS_CLOUDFRONT_KEY_PAIR_ID") ?? throw new ArgumentNullException("AWS_CLOUDFRONT_KEY_PAIR_ID");
        PrivateKey = Environment.GetEnvironmentVariable("AWS_CLOUDFRONT_PRIVATE_KEY") ?? throw new ArgumentNullException("AWS_CLOUDFRONT_PRIVATE_KEY");
        return this;
    }
}