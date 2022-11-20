using System.Security.Cryptography;
using System.Text;

namespace Services;

public class Hash
{
    public string CreateHash(string data)
    {
        var hash = new StringBuilder();

        var sha256 = SHA256.Create();
        var byteData = Encoding.UTF8.GetBytes(data);
        var hashedData = sha256.ComputeHash(byteData);

        foreach (var number in hashedData)
        {
            hash.Append(number.ToString("X2"));
        }

        return hash.ToString();
    }
}
