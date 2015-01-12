namespace System.Reflection
{
    public static class AssemblyExtensions
    {
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
    }
}