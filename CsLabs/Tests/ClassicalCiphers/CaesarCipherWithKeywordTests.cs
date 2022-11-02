using ClassicalCiphers;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ClassicalCiphers;

[TestFixture]
public class CaesarCipherWithKeywordTests
{
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipherWithKeyword(7, "secret");
        var message = "helloworld";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
