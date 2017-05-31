using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides a set of extensions for dictionaries
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Create a readonly copy of the dictionary.
        /// </summary>
        /// <typeparam name="T">The dictionary's key type</typeparam>
        /// <typeparam name="U">The dictionary's value type</typeparam>
        /// <param name="dictionary">The dictionary to copy</param>
        /// <returns>A readonly copy of the dictionary</returns>
        public static ReadOnlyDictionary<T, U> AsReadOnly<T, U>( this IDictionary<T, U> dictionary )
            => new ReadOnlyDictionary<T, U>( dictionary );
    }
}