namespace System.Drawing
{
    public static class RectangleExtensions
    {
        public static void Deconstruct( this Rectangle rect, out int x, out int y, out int width, out int height )
        {
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }

        public static void Deconstruct( this RectangleF rect, out float x, out float y, out float width, out float height )
        {
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }
    }
}
