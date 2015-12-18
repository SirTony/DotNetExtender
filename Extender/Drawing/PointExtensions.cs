namespace System.Drawing
{
    public static class PointExtensions
    {
        public static Point Rotate( this Point point, Point centre, double angle )
        {
            var radians = angle * ( Math.PI / 180 );
            var cos = Math.Cos( radians );
            var sin = Math.Sin( radians );

            var x = cos * ( point.X - centre.X ) - sin * ( point.Y - centre.Y ) + centre.X;
            var y = sin * ( point.X - centre.X ) + cos * ( point.Y - centre.Y ) + centre.Y;

            return new Point( (int)x, (int)y );
        }
    }
}