using CsLabs;
using CsLabs.Extensions;
using static SymmetricCiphers.DesCipher.DesConstants;

namespace SymmetricCiphers.DesCipher
{
    public class DesCipher : ICipher
    {
        private readonly string key;

        public DesCipher(string key)
        {
            this.key = key;
        }

        //  Permute input hexadecimal according to specified sequence
        private static string Permute(int[] sequence, string input)
        {
            var binary = StringExtensions.Hex2Binary(input);

            var permutation = "";

            foreach (var number in sequence)
            {
                permutation += binary[number - 1];
            }

            return StringExtensions.Binary2Hex(permutation);
        }

        private static string ShiftLeft(string str, int d)
        {
            var binary = StringExtensions.Hex2Binary(str);
            var leftShift = string.Concat(binary.AsSpan(d, binary.Length - d), binary.AsSpan(0, d));
            leftShift = StringExtensions.Binary2Hex(leftShift);

            return leftShift;
        }

        private static string[] GetKeys(string key)
        {
            var keys = new string[16];

            //  first key permutation
            key = Permute(Pc1, key);

            for (var i = 0; i < 16; i++)
            {
                key = ShiftLeft(key.Substring(0, 7), ShiftBits[i])
                      + ShiftLeft(key.Substring(7, 7), ShiftBits[i]);

                //  second key permutation
                keys[i] = Permute(Pc2, key);
            }

            return keys;
        }

        private static string SBoxLookup(string input)
        {
            var output = "";
            var binary = StringExtensions.Hex2Binary(input);
            for (var i = 0; i < 48; i += 6)
            {
                var temp = binary.Substring(i, 6);
                var num = i / 6;
                var row = Convert.ToInt32(temp[0] + "" + temp[5], 2);
                var col = Convert.ToInt32(temp.Substring(1, 4), 2);
                output += Convert.ToString(SBox[num, row, col], 16);
            }

            return output;
        }

        private static string Round(string input, string key)
        {
            //  Dividing the input string into 2 parts
            var left = input.Substring(0, 8);
            var right = input.Substring(8, 8);

            //  Expansion permutation
            var temp = Permute(Ep, right);

            //  xor temp and key
            temp = StringExtensions.HexXor(temp, key);

            //  lookup in s-box table
            temp = SBoxLookup(temp);

            //  Straight D-box
            temp = Permute(P, temp);

            //  xor
            left = StringExtensions.HexXor(left, temp);

            return right + left;
        }

        public string Encrypt(string input)
        {
            //  get 16 keys
            var keys = GetKeys(key);

            //  initial permutation
            input = Permute(Ip, input);

            //  16 rounds
            for (var i = 0; i < 16; i++)    
            {
                input = Round(input, keys[i]);
            }

            //  last swap
            input = input.Substring(8, 8) + input.Substring(0, 8);

            //  final permutation
            input = Permute(Ip1, input);
            return input;
        }

        public string Decrypt(string input)
        {
            //  get 16 keys
            var keys = GetKeys(key);

            //  initial permutation
            input = Permute(Ip, input);

            //  16-rounds
            for (var i = 15; i > -1; i--)
            {
                input = Round(input, keys[i]);
            }

            //  32-bit swap
            input = input.Substring(8, 8) + input.Substring(0, 8);
            input = Permute(Ip1, input);
            return input;
        }
    }
}
