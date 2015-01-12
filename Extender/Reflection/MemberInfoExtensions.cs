namespace System.Reflection
{
    /// <summary>
    /// Provides extensions for various <c>System.Reflection.MemberInfo</c>.
    /// </summary>
    public static class MemberInfoExtensions
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
    }
}