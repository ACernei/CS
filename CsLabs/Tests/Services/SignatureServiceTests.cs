using FluentAssertions;
using NUnit.Framework;
using Services;

namespace Tests.Services;

[TestFixture]
public class SignatureServiceTests
{
    [Test]
    public void ValidateDigitalSignatureShouldReturnTrue()
    {
        var messageSigner = new DigitalSignatureService();
        var message = "hello";
        var (signedMessage, signature) = messageSigner.Sign(message);

        messageSigner.IsValid(signedMessage, signature).Should().Be(true);
    }
}
