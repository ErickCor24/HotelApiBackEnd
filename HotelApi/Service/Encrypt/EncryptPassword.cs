using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelApi.Service.Encrypt
{
    public class EncryptPassword
    {
        private const char KEY = 'K';
        public static string Encrypt(string input)
        {
            char[] encrypted = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                encrypted[i] = (char)(input[i] ^ KEY);
            }
            return new string(encrypted);
        }

        public static string Decrypt(string input)
        {
            return Encrypt(input); // XOR es reversible con la misma clave
        }
    }
}
