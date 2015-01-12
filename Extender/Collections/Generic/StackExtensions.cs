namespace System.Collections.Generic
{
    public static class StackExtensions
    {
        public static void PushRange<T>( this Stack<T> iStack, IEnumerable<T> iCollection )
        {
            foreach( T Item in iCollection )
                iStack.Push( Item );
        }
    }
}