namespace System.Drawing
{
    /// <summary>
    /// Provides a set of extensions for Point objects
    /// </summary>
    public static class PointExtensions
    {
        /// <summary>
        /// Rotates the point around a centre point
        /// </summary>
        /// <param name="point">The point to rotate</param>
        /// <param name="centre">The centre point to rotate around</param>
        /// <param name="angle">The number of degrees to rotate</param>
        /// <returns>The rotated point</returns>
        public static Point Rotate( this Point point, Point centre, double angle )
        {
            var radians = angle * ( Math.PI / 180 );
            var cos = Math.Cos( radians );
            var sin = Math.Sin( radians );

            return new Point
            {
                X = (int)( cos * ( point.X - centre.X ) - sin * ( point.Y - centre.Y ) + centre.X ),
                Y = (int)( sin * ( point.X - centre.X ) + cos * ( point.Y - centre.Y ) + centre.Y )
            };
        }

        /// <summary>
        /// Support's deconstructing the X and Y values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="point">The point to deconstruct</param>
        /// <param name="x">The destination for the X property</param>
        /// <param name="y">The destination for the Y property</param>
        public static void Deconstruct( this Point point, out int x, out int y )
        {
            x = point.X;
            y = point.Y;
        }

        /// <summary>
        /// Support's deconstructing the X and Y values using deconstructing assignment from C# 7
        /// </summary>
        /// <param name="point">The point to deconstruct</param>
        /// <param name="x">The destination for the X property</param>
        /// <param name="y">The destination for the Y property</param>
        public static void Deconstruct( this PointF point, out float x, out float y )
        {
            x = point.X;
            y = point.Y;
        }
    }
}