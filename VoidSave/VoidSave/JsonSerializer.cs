using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// Default JSON serializer using unity's JsonUtility. Keeps it simple, keeps it readable.
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T obj) where T : class, new() => JsonUtility.ToJson(obj, true);
        public T Deserialize<T>(string serialized) where T : class, new() => JsonUtility.FromJson<T>(serialized);
    }
}
