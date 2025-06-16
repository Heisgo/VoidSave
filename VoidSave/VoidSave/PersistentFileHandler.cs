using System.IO;
using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// Manages files in unity's persistent data path. Auto-creates folders and uses a  .dat  extension by default.
    /// </summary>
    public class PersistentFileHandler : IFileHandler
    {
        private readonly string basePath;
        private readonly string extension;

        /// <summary>
        /// Sets up the handler and makes sure the save folder is ready to go
        /// </summary>
        public PersistentFileHandler(string directory = "saves", string extension = ".dat")
        {
            basePath = Path.Combine(Application.persistentDataPath, directory);
            this.extension = extension;
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }

        public string GetPath(string slot) => Path.Combine(basePath, slot + extension);
        public void Write(string path, string content) => File.WriteAllText(path, content);
        public string Read(string path) => File.ReadAllText(path);
        public bool Exists(string path) => File.Exists(path);
        public void Delete(string path) { if (File.Exists(path)) File.Delete(path); }
    }
}
