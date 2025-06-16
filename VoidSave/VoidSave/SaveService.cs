using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// The heart of the operation. Glues serializer, encryption, and file handling together via DI
    /// Swap out parts like LEGO blocks, zero sweat ;D
    /// </summary>
    public class SaveService<T> : ISaveService<T> where T : class, new()
    {
        private readonly ISerializer serializer;
        private readonly IEncryptionService encryption;
        private readonly IFileHandler fileHandler;

        /// <summary>
        /// Constructor that takes the pieces and calls it a day. Keeps ur hands clean
        /// </summary>
        public SaveService(ISerializer serializer, IEncryptionService encryption, IFileHandler fileHandler)
        {
            this.serializer = serializer;
            this.encryption = encryption;
            this.fileHandler = fileHandler;
        }

        /// <summary>
        /// Runs the whole shebang: serialize, encrypt, write. Your data's tucked in bed
        /// </summary>
        public void Save(string slot, T data)
        {
            var path = fileHandler.GetPath(slot);
            var json = serializer.Serialize(data);
            var encrypted = encryption.Encrypt(json);
            fileHandler.Write(path, encrypted);
        }

        /// <summary>
        /// Fetch, decrypt, deserialize, and hand you an object. If nothing's there, you get a fresh one
        /// </summary>
        public T Load(string slot)
        {
            var path = fileHandler.GetPath(slot);
            if (!fileHandler.Exists(path))
                return new T();

            var encrypted = fileHandler.Read(path);
            var json = encryption.Decrypt(encrypted);
            return serializer.Deserialize<T>(json);
        }

        /// <summary>
        /// Quick check to see if ur save slot has content
        /// </summary>
        public bool Exists(string slot) => fileHandler.Exists(fileHandler.GetPath(slot));

        /// <summary>
        /// Well... it deletes the file. Just like the name says...
        /// </summary>
        public void Delete(string slot) => fileHandler.Delete(fileHandler.GetPath(slot));
    }
}
