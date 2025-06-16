using UnityEngine;

namespace VoidSaveSystem
{
    /// <summary>
    /// The lazy person's dream: one-liners to save, load, check, or delete your data. You're welcome ;D
    /// </summary>
    public static class VoidSave
    {
        /// <summary>
        /// Shoots your data into slot. Literally one line. Boom.
        /// </summary>
        public static void Save<T>(string slot, T data) where T : class, new()
            => SaveServiceFactory.CreateDefault<T>().Save(slot, data);

        /// <summary>
        /// Grabs your data back out in one fell swoop. Fresh if empty. Nice.
        /// </summary>
        public static T Load<T>(string slot) where T : class, new()
            => SaveServiceFactory.CreateDefault<T>().Load(slot);

        /// <summary>
        /// Peeks if something's saved. No need to load if it's empty lol
        /// </summary>
        public static bool Exists<T>(string slot) where T : class, new()
            => SaveServiceFactory.CreateDefault<T>().Exists(slot);

        /// <summary>
        /// Wipes the slot clean
        /// </summary>
        public static void Delete<T>(string slot) where T : class, new()
            => SaveServiceFactory.CreateDefault<T>().Delete(slot);
    }
}
