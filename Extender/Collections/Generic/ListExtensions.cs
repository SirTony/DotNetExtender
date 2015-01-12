namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        public static List<T> Slice<T>( this List<T> iList, int Start, int End )
        {
            if( End < 0 ) End = iList.Count + End;

            int Length = End - Start;
            List<T> NewList = new List<T>( Length );

            for( int i = 0; i < Length; ++i )
                NewList.Add( iList[ i + Start ] );

            return NewList;
        }
    }
}