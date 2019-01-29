namespace System.Reflection
{
    /// <summary>
    ///     Provides a set of extensions for PropertyInfo objects.
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        ///     Retreives the property's getter and wraps it in a strongly typed delegate.
        /// </summary>
        /// <typeparam name="T">The parameter type of the property</typeparam>
        /// <param name="property">The property to wrap</param>
        /// <param name="instance">The instance of an object the property belongs to. Only for instance properties</param>
        /// <param name="nonPublic">Whether or not to bind non-public setters</param>
        /// <returns>A strongly typed delegate that wraps the property's getter</returns>
        public static Func<T> GetGetMethod<T>(
            this PropertyInfo property,
            object instance = null,
            bool nonPublic = false
        )
            => () => (T) property?.GetGetMethod( nonPublic )?.Invoke( instance, null );

        /// <summary>
        ///     Retreives the property's setter and wraps it in a strongly typed delegate.
        /// </summary>
        /// <typeparam name="T">The parameter type of the property</typeparam>
        /// <param name="property">The property to wrap</param>
        /// <param name="instance">The instance of an object the property belongs to. Only for instance properties</param>
        /// <param name="nonPublic">Whether or not to bind non-public setters</param>
        /// <returns>A strongly typed delegate that wraps the property's setter</returns>
        public static Action<T> GetSetMethod<T>(
            this PropertyInfo property,
            object instance = null,
            bool nonPublic = false
        )
            => x => property?.GetSetMethod( nonPublic )?.Invoke( instance, new object[] { x } );
    }
}
