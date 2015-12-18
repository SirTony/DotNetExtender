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

        public static IEnumerable<IEnumerable<T>> Chunks<T>( this IEnumerable<T> enumerable, int chunkSize )
        {
            int len = enumerable.Count();
            for( int i = 0; i < len; i += chunkSize )
                yield return enumerable.Skip( i ).Take( Math.Min( chunkSize, len - i ) );
        }

        public static void ForEach<T>( this IEnumerable<T> enumerable, Action<T> callback )
        {
            foreach( var item in enumerable )
                callback( item );
        }

        public static IEnumerable<T> Slice<T>( this IEnumerable<T> enumerable, int start, int end )
        {
            var count = enumerable.Count();
            if( start < 0 ) start += count;
            if( end < 0 ) end += count;

            if( start < 0 || start >= count )
                throw new ArgumentOutOfRangeException( nameof( start ) );

            if( end < 0 || end >= count )
                throw new ArgumentOutOfRangeException( nameof( end ) );

            var min = Math.Min( start, end );
            var max = Math.Max( start, end );
            var indices = Enumerable.Range( min, max - min );
            return ( end < start ? indices.Reverse() : indices ).Select( enumerable.ElementAt );
        }
    }
}