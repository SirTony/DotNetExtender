namespace System.Drawing
{
    public static class SizeExtensions
    {
        public static void Deconstruct( this Size size, out int width, out int height )
        {
            width = size.Width;
            height = size.Height;
        }

        public static void Deconstruct( this SizeF size, out float width, out float height )
        {
            width = size.Width;
            height = size.Height;
        }
    }
}
