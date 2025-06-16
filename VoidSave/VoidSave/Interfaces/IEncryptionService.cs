using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// Makes your save files all secret-like. Encrypts and decrypts so nosy players can't snoop ;D
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Scrambles plain text into an encrypted mess. Shh.
        /// </summary>
        string Encrypt(string plain);

        /// <summary>
        /// Unscrambles the encrypted text back into readable text
        /// </summary>
        string Decrypt(string encrypted);
    }

}
