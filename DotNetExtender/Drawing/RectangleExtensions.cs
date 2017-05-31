using System.Globalization;

namespace System.Drawing
{
    /// <summary>
    /// Provides a set of extensions for rectangles
    /// </summary>
    public static class RectangleExtensions
    {
        /// <summary>
        /// Support's deconstructing the X, Y, width, and height values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="rect">The rectangle to deconstruct</param>
        /// <param name="x">The destination of the X property</param>
        /// <param name="y">The destination of the Y property</param>
        /// <param name="width">The destination of the width property</param>
        /// <param name="height">The destination of the height property</param>
        public static void Deconstruct( this Rectangle rect, out int x, out int y, out int width, out int height )
        {
            ( x, y ) = rect.Location;
            ( width, height ) = rect.Size;
        }

        /// <summary>
        /// Support's deconstructing the X, Y, width, and height values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="rect">The rectangle to deconstruct</param>
        /// <param name="x">The destination of the X property</param>
        /// <param name="y">The destination of the Y property</param>
        /// <param name="width">The destination of the width property</param>
        /// <param name="height">The destination of the height property</param>
        public static void Deconstruct( this RectangleF rect, out float x, out float y, out float width, out float height )
        {
            ( x, y ) = rect.Location;
            ( width, height ) = rect.Size;
        }
    }
}
