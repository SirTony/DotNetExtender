namespace System.Collections.Generic
{
    /// <summary>
    /// Provides a set of extensions for key/value pairs
    /// </summary>
    public static class KeyValuePairExtensions
    {
        /// <summary>
        /// Support's deconstructing the key and value using deconstructing assignment from C# 7
        /// </summary>
        /// <typeparam name="TKey">The key type</typeparam>
        /// <typeparam name="TValue">The value type</typeparam>
        /// <param name="pair">The pair to deconstruct</param>
        /// <param name="key">The destination variable for the key</param>
        /// <param name="value">The destination variable for the value</param>
        public static void Deconstruct<TKey, TValue>( this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value )
        {
            key = pair.Key;
            value = pair.Value;
        }
    }
}
