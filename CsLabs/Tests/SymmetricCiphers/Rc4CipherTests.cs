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
        var cipher = new Rc4Cipher(new List<byte> { 102, 108, 97, 103 });
        var message = new List<byte> { 97, 110, 100, 114, 101, 105 };

        var encryptedMsg = cipher.Encrypt(message);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.SequenceEqual(message).Should().Be(true);
    }
}
