namespace System.Drawing
{
    /// <summary>
    ///     Provides a set of extensions for Size objects
    /// </summary>
    public static class SizeExtensions
    {
        /// <summary>
        ///     Support's deconstructing the X and Y values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="size">The size to deconstruct</param>
        /// <param name="width">The destination of the width property</param>
        /// <param name="height">The destination of the height property</param>
        public static void Deconstruct( this Size size, out int width, out int height )
        {
            width = size.Width;
            height = size.Height;
        }

        /// <summary>
        ///     Support's deconstructing the X and Y values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="size">The size to deconstruct</param>
        /// <param name="width">The destination of the width property</param>
        /// <param name="height">The destination of the height property</param>
        public static void Deconstruct( this SizeF size, out float width, out float height )
        {
            width = size.Width;
            height = size.Height;
        }
    }
}
