namespace System.Linq
{
    using Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<string> Chunks( this string source, int chunkSize )
        {
            int len = source.Length;
            for( int i = 0; i < len; i += chunkSize )
                yield return source.Substring( i, Math.Min( chunkSize, len - i ) );
        }

        public static IEnumerable<IEnumerable<T>> Chunks<T>( this IEnumerable<T> source, int chunkSize )
        {
            int len = source.Count();
            for( int i = 0; i < len; i += chunkSize )
                yield return source.Skip( i ).Take( Math.Min( chunkSize, len - i ) );
        }
    }
}