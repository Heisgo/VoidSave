using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// It' the magician that defines how objects get turned into text and back again.
    /// JSON, binary, or whatever rabbit you wanna pull from the hat.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Converts the object into its texty doppelganger (lol)
        /// </summary>
        string Serialize<T>(T obj) where T : class, new();

        /// <summary>
        /// Brings the object back to life from its string form. Ta-da!
        /// </summary>
        T Deserialize<T>(string serialized) where T : class, new();
    }
}
