using System.Text;
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
        var message = "HiAndrei";

        var bytes = Encoding.UTF8.GetBytes(message);
        var hexString = Convert.ToHexString(bytes).ToLower();

        var encryptedMsg = cipher.Encrypt(hexString);
        var decryptedMsg = cipher.Decrypt(encryptedMsg);

        decryptedMsg.Should().Be(hexString);
    }
}
