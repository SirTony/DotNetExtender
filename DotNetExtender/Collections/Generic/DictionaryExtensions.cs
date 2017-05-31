using System.Collections.ObjectModel;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static ReadOnlyDictionary<T, U> AsReadOnly<T, U>( this IDictionary<T, U> dictionary )
            => new ReadOnlyDictionary<T, U>( dictionary );
    }
}