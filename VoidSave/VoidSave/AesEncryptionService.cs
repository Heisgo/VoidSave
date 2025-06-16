using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// AES-based encryption service. Uses a base64 key and optional IV to keep your data on lockdown.
    /// </summary>
    public class AesEncryptionService : IEncryptionService
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        /// <summary>
        /// Whips up a new encryption service with your provided base64 key and IV
        /// </summary>
        public AesEncryptionService(string base64Key, string base64IV = null)
        {
            key = Convert.FromBase64String(base64Key);
            iv = base64IV != null ? Convert.FromBase64String(base64IV) : new byte[16];
        }

        public string Encrypt(string plain)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var crypto = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var writer = new StreamWriter(crypto)) writer.Write(plain);
            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string encrypted)
        {
            var data = Convert.FromBase64String(encrypted);
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(data);
            using var crypto = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(crypto);
            return reader.ReadToEnd();
        }
    }
}
