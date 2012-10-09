namespace System.Reflection
{
    /// <summary>
    /// Provides extensions for various System.Reflection types.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets the first attribute of the specified type from the MemberInfo object.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iMemberInfo">The MemberInfo object to get the attributes from.</param>
        /// <returns>The first attribute of the specified type, or null if one is not found.</returns>
        public static T GetCustomAttribute<T>( this MemberInfo iMemberInfo ) where T : Attribute
        {
            return iMemberInfo.GetCustomAttribute<T>( false );
        }

        /// <summary>
        /// Gets the first attribute of the specified type from the MemberInfo object.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iMemberInfo">The MemberInfo object to get the attributes from.</param>
        /// <param name="Inherit">Specified whether or not to search the inheritence chain to find the attribute.</param>
        /// <returns>The first attribute of the specified type, or null if one is not found.</returns>
        public static T GetCustomAttribute<T>( this MemberInfo iMemberInfo, bool Inherit ) where T : Attribute
        {
            T[] Attributes = iMemberInfo.GetCustomAttributes<T>( Inherit );

            if( Attributes.Length == 0 )
                return null;
            else
                return Attributes[0];
        }

        /// <summary>
        /// Gets an array of all attributes of the specified type from the MemberInfo object.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iMemberInfo">The MemberInfo object to get the attributes from.</param>
        /// <returns>An array of attributes of the specified type.</returns>
        public static T[] GetCustomAttributes<T>( this MemberInfo iMemberInfo ) where T : Attribute
        {
            return iMemberInfo.GetCustomAttributes<T>( false );
        }

        /// <summary>
        /// Gets an array of all attributes of the specified type from the MemberInfo object.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iMemberInfo">The MemberInfo object to get the attributes from.</param>
        /// <param name="Inherit">Specified whether or not to search the inheritence chain to find the attribute.</param>
        /// <returns>An array of attributes of the specified type.</returns>
        public static T[] GetCustomAttributes<T>( this MemberInfo iMemberInfo, bool Inherit ) where T : Attribute
        {
            object[] Attributes = iMemberInfo.GetCustomAttributes( typeof( T ), Inherit );
            T[] Result = new T[Attributes.Length];
            Array.Copy( Attributes, Result, Result.Length );

            return Result;
        }

        /// <summary>
        /// Gets the first attribute of the specified type from an Assembly.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iAssembly">The Assembly object to get the attribute from.</param>
        /// <returns>The first attribute of the specified type, or null if none were found.</returns>
        public static T GetCustomAttribute<T>( this Assembly iAssembly ) where T : Attribute
        {
            T[] Attributes = iAssembly.GetCustomAttributes<T>();

            if( Attributes.Length == 0 )
                return null;
            else
                return Attributes[0];
        }

        /// <summary>
        /// Gets an array of attributes of the specified type from an Assembly.
        /// </summary>
        /// <typeparam name="T">Any type that inherits from System.Attribute.</typeparam>
        /// <param name="iAssembly">The Assembly object to get the attributes from.</param>
        /// <returns>An array of attributes of the specified type.</returns>
        public static T[] GetCustomAttributes<T>( this Assembly iAssembly ) where T : Attribute
        {
            object[] Attributes = iAssembly.GetCustomAttributes( typeof( T ), false );
            T[] Result = new T[Attributes.Length];
            Array.Copy( Attributes, Result, Result.Length );

            return Result;
        }

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