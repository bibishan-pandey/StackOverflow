using System.Security.Cryptography;
using System.Text;

namespace StackOverflow.ServiceLayers.Helpers
{
    public class Sha256HashGenerator
    {
        public static string GenerateHash(string toBeHashedText)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(toBeHashedText));
                var stringBuilder = new StringBuilder();
                foreach (var b in bytes)
                    stringBuilder.Append(b.ToString("x2"));

                return stringBuilder.ToString();
            }
        }
    }
}
