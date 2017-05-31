using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace System.Drawing
{
    /// <summary>
    /// Provides extensions methods to the System.Drawing.Image class.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Tests whether or not the image contains multiple frames, only for Motion JPEGs and GIFs.
        /// </summary>
        /// <param name="image">The image to be tested.</param>
        /// <returns>True if the image is animated, false otherwise.</returns>
        public static bool IsAnimated( this Image image )
        {
            try
            {
                return image.GetFrameCount( FrameDimension.Time ) > 1;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a property item from the image's metadata
        /// </summary>
        /// <param name="image">The image to read the property from</param>
        /// <param name="property">The propert to retrieve</param>
        /// <returns>The property item from the image</returns>
        public static PropertyItem GetPropertyItem( this Image image, PropertyTag property )
            => image.GetPropertyItem( (int)property );

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="size">A System.Drawing.Size struct containing the maximum possible size of the new image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, Size size )
            => image.Scale( size.Width, size.Height );

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="size">A System.Drawing.Size struct containing the maximum possible size of the new image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, SizeF size )
            => image.Scale( size.Width, size.Height );

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="width">The maximum allowable width for the resized image.</param>
        /// <param name="height">The maximum allowable height for the resized image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, int width, int height )
            => image.Scale( (float)width, (float)height );

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="width">The maximum allowable width for the resized image.</param>
        /// <param name="height">The maximum allowable height for the resized image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, float width, float height )
        {
            var x = width / image.Width;
            var y = height / image.Height;
            var ratio = Math.Min( x, y );

            return image.Scale( ratio );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="percent">The percentage by which to scale the image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, int percent )
        {
            return image.Scale( percent / 100.0f );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="image">The image to be scaled.</param>
        /// <param name="ratio">The ratio by which to scale the image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image image, float ratio )
        {
            var width = image.Width * ratio;
            var height = image.Height * ratio;

            var scaled = new Bitmap( (int)width, (int)height );
            using( var graphics = Graphics.FromImage( scaled ) )
            {
                graphics.SetMaxQuality();
                graphics.DrawImage( image, 0, 0, width, height );
            }

            return scaled;
        }

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="image">The image to be resized.</param>
        /// <param name="size">The new size of the image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image image, Size size )
            => image.Resize( size.Width, size.Height );

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="image">The image to be resized.</param>
        /// <param name="width">The new width of the resized image.</param>
        /// <param name="height">The new height of the resized image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image image, int width, int height )
            => image.Resize( (float)width, (float)height );

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="image">The image to be resized.</param>
        /// <param name="size">The new size of the image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image image, SizeF size )
            => image.Resize( size.Width, size.Height );

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="image">The image to be resized.</param>
        /// <param name="width">The new width of the resized image.</param>
        /// <param name="height">The new height of the resized image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image image, float width, float height )
        {
            var resized = new Bitmap( (int)width, (int)height );
            using( var graphics = Graphics.FromImage( resized ) )
            {
                graphics.SetMaxQuality();
                graphics.DrawImage( image, 0, 0, width, height );
            }

            return resized;
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="x">The X coordinate to start from.</param>
        /// <param name="y">The Y coordinate to start from.</param>
        /// <param name="width">The width of the cropped area.</param>
        /// <param name="height">The height of the cropped area.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, int x, int y, int width, int height )
            => image.Crop( new Rectangle( x, y, width, height ) );

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="location">The location of the area to crop.</param>
        /// <param name="size">The size of the area to crop.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, Point location, Size size )
            => image.Crop( new Rectangle( location, size ) );

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="rectangle">The area to crop from the original image.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, Rectangle rectangle )
            => image.Crop( new RectangleF( rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height ) );

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="x">The X coordinate to start from.</param>
        /// <param name="y">The Y coordinate to start from.</param>
        /// <param name="width">The width of the cropped area.</param>
        /// <param name="height">The height of the cropped area.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, float x, float y, float width, float height )
            => image.Crop( new RectangleF( x, y, width, height ) );

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="location">The location of the area to crop.</param>
        /// <param name="size">The size of the area to crop.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, PointF location, SizeF size )
            => image.Crop( new RectangleF( location, size ) );

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="image">The image to be cropped.</param>
        /// <param name="rectangle">The area to crop from the original image.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image image, RectangleF rectangle )
        {
            var cropped = new Bitmap( (int)rectangle.Width, (int)rectangle.Height );
            using( Graphics graphics = Graphics.FromImage( cropped ) )
            {
                graphics.SetMaxQuality();
                graphics.Clear( Color.Transparent );
                var destination = new RectangleF( 0, 0, rectangle.Width, rectangle.Height );
                graphics.DrawImage( image, destination, rectangle, GraphicsUnit.Pixel );
            }

            return cropped;
        }

        /// <summary>
        /// Saves the Image object to the specified file, creating it if it does not exist, overwriting it otherwise.
        /// </summary>
        /// <param name="image">The Image object to write to disk.</param>
        /// <param name="fileName">The absolute or relative path to the file.</param>
        public static void SaveJpeg( this Image image, string fileName )
            => image.SaveJpeg( File.Open( fileName, FileMode.Create, FileAccess.Write, FileShare.Read ), 75 );

        /// <summary>
        /// Saves the Image object to the specified file, creating it if it does not exist, overwriting it otherwise.
        /// </summary>
        /// <param name="image">The Image object to write to disk.</param>
        /// <param name="fileName">The absolute or relative path to the file.</param>
        /// <param name="quality">The quality of the JPEG, must be between 0 and 100 (inclusive).</param>
        public static void SaveJpeg( this Image image, string fileName, int quality )
            => image.SaveJpeg( File.Open( fileName, FileMode.Create, FileAccess.Write, FileShare.Read ), quality );

        /// <summary>
        /// Writes the Image object to the specified System.IO.Stream object.
        /// </summary>
        /// <param name="image">The Image object to write.</param>
        /// <param name="stream">The stream to write the compressed and encoded image to.</param>
        public static void SaveJpeg( this Image image, Stream stream )
            => image.SaveJpeg( stream, 75 );

        /// <summary>
        /// Writes the Image object to the specified System.IO.Stream object.
        /// </summary>
        /// <param name="image">The Image object to write.</param>
        /// <param name="stream">The stream to write the compressed and encoded image to.</param>
        /// <param name="quality">The quality of the JPEG, must be between 0 and 100 (inclusive).</param>
        public static void SaveJpeg( this Image image, Stream stream, int quality )
        {
            if( quality < 0 || quality > 100 )
                throw new ArgumentOutOfRangeException( nameof(quality), "Quality must be between 0 and 100, inclusive." );

            var codec = ImageFormat.Jpeg.GetEncoder();

            if( codec == null )
                image.Save( stream, ImageFormat.Jpeg );
            else
            {
                var @params = new EncoderParameters( 1 )
                {
                    Param = { [0] = new EncoderParameter( Encoder.Quality, quality ) }
                };

                image.Save( stream, codec, @params );
            }
        }

        /// <summary>
        /// Sets the Graphics object to prouce maximum quality images.
        /// </summary>
        /// <param name="graphics">The Graphics object to alter.</param>
        private static void SetMaxQuality( this Graphics graphics )
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
        }
    }
}
