namespace System.Reflection
{
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="method">The MethodInfo object to wrap.</param>
        /// <param name="instance">An instance of the object that the delegate is to be called on, only for instance types.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo method, object instance ) where T : class
            => (T)(object)Delegate.CreateDelegate( typeof( T ), instance, method );

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="method">The MethodInfo object to wrap.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo method ) where T : class
            => (T)(object)Delegate.CreateDelegate( typeof( T ), null, method );

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="method">The MethodInfo object to wrap.</param>
        /// <param name="instance">An instance of the object that the delegate is to be called on, only for instance types.</param>
        /// <param name="throwOnBindFailure">Whether or not to throw an exception if the binding fails.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo method, object instance, bool throwOnBindFailure ) where T : class
            => (T)(object)Delegate.CreateDelegate( typeof( T ), instance, method, throwOnBindFailure );

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="method">The MethodInfo object to wrap.</param>
        /// <param name="throwOnBindFailure">Whether or not to throw an exception if the binding fails.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo method, bool throwOnBindFailure ) where T : class
            => (T)(object)Delegate.CreateDelegate( typeof( T ), null, method, throwOnBindFailure );
    }
}