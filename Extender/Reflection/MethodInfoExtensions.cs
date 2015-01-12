namespace System.Reflection
{
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="iMethodInfo">The MethodInfo object to wrap.</param>
        /// <param name="Instance">An instance of the object that the delegate is to be called on, only for instance types.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo iMethodInfo, object Instance ) where T : class
        {
            return (T)(object)Delegate.CreateDelegate( typeof( T ), Instance, iMethodInfo );
        }

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="iMethodInfo">The MethodInfo object to wrap.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo iMethodInfo ) where T : class
        {
            return (T)(object)Delegate.CreateDelegate( typeof( T ), null, iMethodInfo );
        }

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="iMethodInfo">The MethodInfo object to wrap.</param>
        /// <param name="Instance">An instance of the object that the delegate is to be called on, only for instance types.</param>
        /// <param name="ThrowOnBindFailure">Whether or not to throw an exception if the binding fails.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo iMethodInfo, object Instance, bool ThrowOnBindFailure ) where T : class
        {
            return (T)(object)Delegate.CreateDelegate( typeof( T ), Instance, iMethodInfo, ThrowOnBindFailure );
        }

        /// <summary>
        /// Creates a callable delegate from a MethodInfo object.
        /// </summary>
        /// <typeparam name="T">A System.Delegate.</typeparam>
        /// <param name="iMethodInfo">The MethodInfo object to wrap.</param>
        /// <param name="ThrowOnBindFailure">Whether or not to throw an exception if the binding fails.</param>
        /// <returns>A callable delegate wrapped on the MethodInfo object.</returns>
        public static T CreateDelegate<T>( this MethodInfo iMethodInfo, bool ThrowOnBindFailure ) where T : class
        {
            return (T)(object)Delegate.CreateDelegate( typeof( T ), null, iMethodInfo, ThrowOnBindFailure );
        }
    }
}