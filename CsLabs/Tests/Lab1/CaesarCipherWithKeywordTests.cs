using FluentAssertions;
using Lab1;
using NUnit.Framework;

namespace Tests.Lab1;

[TestFixture]
public class CaesarCipherWithKeywordTests
{
    [Test]
    public void EncryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipherWithKeyword(7, "secret");
        var message = "helloworld";
        var expected = "ofvvyryhvl";

        var encryptedMsg = cipher.Encrypt(message);
        encryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void DecryptShouldReturnCorrectMessage()
    {
        var cipher = new CaesarCipherWithKeyword(7, "secret");
        var message = "ofvvyryhvl";
        var expected = "helloworld";

        var decryptedMsg = cipher.Decrypt(message);
        decryptedMsg.Should().Be(expected);
    }
    
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
