using Amazon.CloudFront;
using Amazon.S3;
using Amazon.S3.Model;
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
    
    public async Task UploadFileAsync(Stream fileStream, string key, string contentType)
    {
        try
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = key,
                InputStream = fileStream,
                ContentType = contentType
            };

            await _s3Client.PutObjectAsync(putRequest);
        }
        catch (AmazonS3Exception ex)
        {
            throw new ApplicationException($"Error uploading to S3: {ex.Message}", ex);
        }
    }

    public async Task DeleteFileAsync(string key)
    {
        try
        {
            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = _awsSettings.BucketName,
                Key = key,
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }
        catch (AmazonS3Exception ex)
        {
            throw new ApplicationException($"Error deleting from S3: {ex.Message}", ex);
        }
    }

    public Task<Stream> DownloadFileAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]> DownloadFileAsBytesAsync(string key)
    {
        throw new NotImplementedException();
    }

    public string GeneratePresignedUrlAsync(string? key, TimeSpan expiration)
    {
        return AmazonCloudFrontUrlSigner.GetCannedSignedURL(
            AmazonCloudFrontUrlSigner.Protocol.https,
            _awsSettings.CloudFrontDomain,
            new StringReader(_awsSettings.PrivateKey),
            key,
            _awsSettings.KeyPairId,
            DateTime.UtcNow.Add(expiration));
    }
}