using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// A simple facade that save and load data of type <typeparamref name="T"/>
    /// Think of it as the friendly librarian that knows exactly where your data goes and how to get it back
    /// </summary>
    public interface ISaveService<T> where T : class, new()
    {
        /// <summary>
        /// Saves the provided data into the given slot. Overwrites any existing save without fuss
        /// </summary>
        void Save(string slot, T data);

        /// <summary>
        /// Loads data from the given slot. If nothing is found, you get a fresh instance of <typeparamref name="T"/>
        /// </summary>
        T Load(string slot);

        /// <summary>
        /// Checks if a save exists in the given slot. Handy for guarding your load calls
        /// </summary>
        bool Exists(string slot);

        /// <summary>
        /// Deletes a save file in the given slot. Clean slate whenever you need it
        /// </summary>
        void Delete(string slot);
    }
}