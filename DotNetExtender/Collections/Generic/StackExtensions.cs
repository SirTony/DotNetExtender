using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Provides a set of extension for stacks
    /// </summary>
    public static class StackExtensions
    {
        /// <summary>
        ///     Pushes multiple items onto the top of the stack. The collection that is pushed will end up on the stack in reverse
        ///     order
        /// </summary>
        /// <typeparam name="T">The stack's element type</typeparam>
        /// <param name="stack">The stack to push to</param>
        /// <param name="enumerable">The range of items to push</param>
        public static void PushRange<T>( this Stack<T> stack, IEnumerable<T> enumerable )
            => enumerable.ForEach( stack.Push );
    }
}
