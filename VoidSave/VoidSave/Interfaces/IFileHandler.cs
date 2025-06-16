using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// The handyman of file ops. Writes, reads, checks, and deletes files, plus figures out where to stash them
    /// </summary>
    public interface IFileHandler
    {
        /// <summary>Blasts content into the file at the given path.</summary>
        void Write(string path, string content);

        /// <summary>Pulls all the text from the file. Easy-peasy.</summary>
        string Read(string path);

        /// <summary>Checks if the file exists at that path.</summary>
        bool Exists(string path);

        /// <summary>Removes the file if it's hanging around.</summary>
        void Delete(string path);

        /// <summary>Builds the full file path for your save slot. No guessing games c:</summary>
        string GetPath(string slot);
    }
}
