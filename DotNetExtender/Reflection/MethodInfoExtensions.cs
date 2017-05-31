namespace System.Reflection
{
    /// <summary>
    /// Provides a set of extensions for MethodInfo objects
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A delegate type</typeparam>
        /// <param name="method">The MethodInfo object to wrap</param>
        /// <param name="instance">An instance of the object that the delegate is to be called on, only for instance methods</param>
        /// <param name="throwOnBindFailure">Whether or not to throw an exception if the binding fails</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object</returns>
        public static T CreateDelegate<T>( this MethodInfo method, object instance = null, bool throwOnBindFailure = true ) where T : class
            => (T)(object)Delegate.CreateDelegate( typeof( T ), instance, method, throwOnBindFailure );
    }
}