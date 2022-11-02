using FluentAssertions;
using NUnit.Framework;
using SymmetricCiphers.DesCipher;

namespace Tests.SymmetricCiphers;

public class DesCipherTests
{
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new DesCipher("666c6167666c6167");
        var message = "da89c2a294e55137";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
