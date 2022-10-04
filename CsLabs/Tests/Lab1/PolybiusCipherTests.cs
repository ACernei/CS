using FluentAssertions;
using Lab1;
using NUnit.Framework;

namespace Tests.Lab1;

[TestFixture]
public class PolybiusCipherTests
{
    [Test]
    public void EncryptShouldReturnCorrectMessage()
    {
        var cipher = new PolybiusCipher("secret");
        var message = "helloworld";
        var expected = "31123434425242143423";

        var encryptedMsg = cipher.Encrypt(message);
        encryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void DecryptShouldReturnCorrectMessage()
    {
        var cipher = new PolybiusCipher("secret");
        var message = "31123434425242143423";
        var expected = "helloworld";

        var decryptedMsg = cipher.Decrypt(message);
        decryptedMsg.Should().Be(expected);
    }
    
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new PolybiusCipher("secret");
        var message = "helloworld";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
