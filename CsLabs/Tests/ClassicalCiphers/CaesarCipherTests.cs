using ClassicalCiphers;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ClassicalCiphers;

[TestFixture]
public class CaesarCipherTests
{
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipher(7);
        var message = "helloworld";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
