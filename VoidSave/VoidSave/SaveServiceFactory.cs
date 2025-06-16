using System;
using System.Text;
using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// Spins up a default save service with JSON + AES + persistent files. All set, zero headaches
    /// </summary>
    public static class SaveServiceFactory
    {
        private const string defaultKeyString = "uYOHTDnpCUxJcQ8z1r5pE+Zuw1W5KyHyjCefkb9qbfQ="; // You can change this, or even make it more secure (it never changes so you should probably not use a persistent key if ur storing really important data)

        /// <summary>
        /// Gives you a ready-made save service for your data type. No assembly required
        /// </summary>
        public static ISaveService<T> CreateDefault<T>() where T : class, new()
        {
            var serializer = new JsonSerializer();
            //var base64Key = Convert.ToBase64String(Encoding.UTF8.GetBytes(defaultKeyString));
            var crypto = new AesEncryptionService(defaultKeyString);
            var files = new PersistentFileHandler();
            return new SaveService<T>(serializer, crypto, files);
        }
    }
}
