using AsymmetricCiphers;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.AsymmetricCiphers;

[TestFixture]
public class RsaCipherTests
{
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new RsaCipher(547, 659);
        var message = "secret";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
