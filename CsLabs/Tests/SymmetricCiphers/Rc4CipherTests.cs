using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;
using SymmetricCiphers.Rc4Cipher;

namespace Tests.SymmetricCiphers;

public class Rc4CipherTests
{
    [Test]
    public void EncryptThenDecryptShouldReturnCorrectMessage()
    {
        var cipher = new Rc4Cipher("flag");
        var message = "andrei";

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(message);
    }
}
