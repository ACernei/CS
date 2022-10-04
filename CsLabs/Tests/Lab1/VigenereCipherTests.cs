using FluentAssertions;
using Lab1;
using NUnit.Framework;

namespace Tests.Lab1;

[TestFixture]
public class VigenereCipherTests
{
    [Test]
    public void EncryptShouldReturnCorrectMessage()
    {
        var cipher = new VigenereCipher("secret");
        var message = "helloworld";
        var expected = "zincspgvnu";

        var encryptedMsg = cipher.Encrypt(message);
        encryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void DecryptShouldReturnCorrectMessage()
    {
        var cipher = new VigenereCipher("secret");
        var message = "zincspgvnu";
        var expected = "helloworld";

        var decryptedMsg = cipher.Decrypt(message);
        decryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new VigenereCipher("secret");
        var message = "helloworld";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
