using Amazon.CloudFront;
using Amazon.S3;
using BistroQ.Core.Common.Settings;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class AwsStorageService : ICloudStorageService
{
    private readonly IAmazonS3 _s3Client;
    private readonly AwsSettings _awsSettings;
    
    public AwsStorageService(IAmazonS3 s3Client, AwsSettings awsSettings)
    {
        _awsSettings = awsSettings;
        _s3Client = s3Client;
    }
    
    public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string fileUrl)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> DownloadFileAsync(string fileUrl)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]> DownloadFileAsBytesAsync(string fileUrl)
    {
        throw new NotImplementedException();
    }

    public Task<string> GeneratePresignedUrlAsync(string fileUrl, TimeSpan expiration)
    {
        return Task.FromResult(AmazonCloudFrontUrlSigner.GetCannedSignedURL(
            AmazonCloudFrontUrlSigner.Protocol.https,
            _awsSettings.CloudFrontDomain,
            new StringReader(_awsSettings.PrivateKey),
            fileUrl,
            _awsSettings.KeyPairId,
            DateTime.UtcNow.Add(expiration)));
    }
}