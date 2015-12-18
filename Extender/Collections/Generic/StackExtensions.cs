namespace System.Collections.Generic
{
    public static class StackExtensions
    {
        public static void PushRange<T>( this Stack<T> stack, IEnumerable<T> enumerable )
        {
            foreach( T Item in enumerable )
                stack.Push( Item );
        }
    }
}