using FluentAssertions;
using Lab1;
using NUnit.Framework;

namespace Tests.Lab1;

[TestFixture]
public class CaesarCipherTests
{
    [Test]
    public void EncryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipher(7);
        var message = "helloworld";
        var expected = "olssvdvysk";

        var encryptedMsg = cipher.Encrypt(message);
        encryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void DecryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipher(7);
        var message = "olssvdvysk";
        var expected = "helloworld";

        var decryptedMsg = cipher.Decrypt(message);
        decryptedMsg.Should().Be(expected);
    }
    
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
