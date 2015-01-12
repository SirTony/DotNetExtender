namespace System.Drawing
{
    using Drawing2D;
    using Imaging;
    using IO;

    /// <summary>
    /// Provides extensions methods to the System.Drawing.Image class.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Tests whether or not the image contains multiple frames, only for Motion JPEGs and GIFs.
        /// </summary>
        /// <param name="Source">The image to be tested.</param>
        /// <returns>True if the image is animated, false otherwise.</returns>
        public static bool IsAnimated( this Image Source )
        {
            try
            {
                return Source.GetFrameCount( FrameDimension.Time ) > 1;
            }
            catch
            {
                return false;
            }
        }

        public static PropertyItem GetPropertyItem( this Image source, PropertyTag propertyTag )
        {
            return source.GetPropertyItem( (int)propertyTag );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="MaxSize">A System.Drawing.Size struct containing the maximum possible size of the new image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, Size MaxSize )
        {
            return Source.Scale( (float)MaxSize.Width, (float)MaxSize.Height );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="MaxSize">A System.Drawing.Size struct containing the maximum possible size of the new image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, SizeF MaxSize )
        {
            return Source.Scale( MaxSize.Width, MaxSize.Height );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="MaxWidth">The maximum allowable width for the resized image.</param>
        /// <param name="MaxHeight">The maximum allowable height for the resized image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, int MaxWidth, int MaxHeight )
        {
            return Source.Scale( (float)MaxWidth, (float)MaxHeight );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="MaxWidth">The maximum allowable width for the resized image.</param>
        /// <param name="MaxHeight">The maximum allowable height for the resized image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, float MaxWidth, float MaxHeight )
        {
            float RatioX = MaxWidth / Source.Width;
            float RatioY = MaxHeight / Source.Height;
            float Ratio = Math.Min( RatioX, RatioY );

            return Source.Scale( Ratio );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="Percent">The percentage by which to scale the image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, int Percent )
        {
            return Source.Scale( 100.0f - ( ( (float)Percent ) / 100.0f ) );
        }

        /// <summary>
        /// Scales the image, maintaining the aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be scaled.</param>
        /// <param name="Ratio">The ratio by which to scale the image.</param>
        /// <returns>An Image object containing the resized image.</returns>
        public static Image Scale( this Image Source, float Ratio )
        {
            float NewWidth = Source.Width * Ratio;
            float NewHeight = Source.Height * Ratio;

            Bitmap Scaled = new Bitmap( (int)NewWidth, (int)NewHeight );

            using( Graphics Gfx = Graphics.FromImage( Scaled ) )
            {
                Gfx.SetMaxQuality();
                Gfx.DrawImage( Source, 0, 0, NewWidth, NewHeight );
            }

            return Scaled;
        }

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be resized.</param>
        /// <param name="NewSize">The new size of the image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image Source, Size NewSize )
        {
            return Source.Resize( (float)NewSize.Width, (float)NewSize.Height );
        }

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be resized.</param>
        /// <param name="Width">The new width of the resized image.</param>
        /// <param name="Height">The new height of the resized image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image Source, int Width, int Height )
        {
            return Source.Resize( (float)Width, (float)Height );
        }

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be resized.</param>
        /// <param name="NewSize">The new size of the image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image Source, SizeF NewSize )
        {
            return Source.Resize( NewSize.Width, NewSize.Height );
        }

        /// <summary>
        /// Resizes the image to the specified size, not maintaining aspect ratio.
        /// </summary>
        /// <param name="Source">The image to be resized.</param>
        /// <param name="Width">The new width of the resized image.</param>
        /// <param name="Height">The new height of the resized image.</param>
        /// <returns>The resized image.</returns>
        public static Image Resize( this Image Source, float Width, float Height )
        {
            Bitmap Resized = new Bitmap( (int)Width, (int)Height );

            using( Graphics Gfx = Graphics.FromImage( Resized ) )
            {
                Gfx.SetMaxQuality();
                Gfx.DrawImage( Source, 0, 0, Width, Height );
            }

            return Resized;
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="X">The X coordinate to start from.</param>
        /// <param name="Y">The Y coordinate to start from.</param>
        /// <param name="Width">The width of the cropped area.</param>
        /// <param name="Height">The height of the cropped area.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, int X, int Y, int Width, int Height )
        {
            return Source.Crop( new Rectangle( X, Y, Width, Height ) );
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="CropLocation">The location of the area to crop.</param>
        /// <param name="CropSize">The size of the area to crop.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, Point CropLocation, Size CropSize )
        {
            return Source.Crop( new Rectangle( CropLocation, CropSize ) );
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="CropArea">The area to crop from the original image.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, Rectangle CropArea )
        {
            return Source.Crop( new RectangleF( CropArea.X, CropArea.Y, CropArea.Width, CropArea.Height ) );
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="X">The X coordinate to start from.</param>
        /// <param name="Y">The Y coordinate to start from.</param>
        /// <param name="Width">The width of the cropped area.</param>
        /// <param name="Height">The height of the cropped area.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, float X, float Y, float Width, float Height )
        {
            return Source.Crop( new RectangleF( X, Y, Width, Height ) );
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="CropLocation">The location of the area to crop.</param>
        /// <param name="CropSize">The size of the area to crop.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, PointF CropLocation, SizeF CropSize )
        {
            return Source.Crop( new RectangleF( CropLocation, CropSize ) );
        }

        /// <summary>
        /// Crops a portion of the image.
        /// </summary>
        /// <param name="Source">The image to be cropped.</param>
        /// <param name="CropArea">The area to crop from the original image.</param>
        /// <returns>The cropped image.</returns>
        public static Image Crop( this Image Source, RectangleF CropArea )
        {
            Bitmap Cropped = new Bitmap( (int)CropArea.Width, (int)CropArea.Height );

            using( Graphics Gfx = Graphics.FromImage( Cropped ) )
            {
                Gfx.SetMaxQuality();
                Gfx.Clear( Color.Transparent );
                RectangleF Destination = new RectangleF( 0, 0, CropArea.Width, CropArea.Height );
                Gfx.DrawImage( Source, Destination, CropArea, GraphicsUnit.Pixel );
            }

            return Cropped;
        }

        /// <summary>
        /// Saves the Image object to the specified file, creating it if it does not exist, overwriting it otherwise.
        /// </summary>
        /// <param name="Source">The Image object to write to disk.</param>
        /// <param name="FileName">The absolute or relative path to the file.</param>
        public static void SaveJpeg( this Image Source, string FileName )
        {
            Source.SaveJpeg( File.Open( FileName, FileMode.Create, FileAccess.Write, FileShare.Read ), 75 );
        }

        /// <summary>
        /// Saves the Image object to the specified file, creating it if it does not exist, overwriting it otherwise.
        /// </summary>
        /// <param name="Source">The Image object to write to disk.</param>
        /// <param name="FileName">The absolute or relative path to the file.</param>
        /// <param name="Quality">The quality of the JPEG, must be between 0 and 100 (inclusive).</param>
        public static void SaveJpeg( this Image Source, string FileName, int Quality )
        {
            Source.SaveJpeg( File.Open( FileName, FileMode.Create, FileAccess.Write, FileShare.Read ), Quality );
        }

        /// <summary>
        /// Writes the Image object to the specified System.IO.Stream object.
        /// </summary>
        /// <param name="Source">The Image object to write.</param>
        /// <param name="Output">The stream to write the compressed and encoded image to.</param>
        public static void SaveJpeg( this Image Source, Stream Output )
        {
            Source.SaveJpeg( Output, 75 );
        }

        /// <summary>
        /// Writes the Image object to the specified System.IO.Stream object.
        /// </summary>
        /// <param name="Source">The Image object to write.</param>
        /// <param name="Output">The stream to write the compressed and encoded image to.</param>
        /// <param name="Quality">The quality of the JPEG, must be between 0 and 100 (inclusive).</param>
        public static void SaveJpeg( this Image Source, Stream Output, int Quality )
        {
            if( Quality < 0 || Quality > 100 )
                throw new ArgumentOutOfRangeException( "Quality", "Quality must be between 0 and 100, inclusive." );

            ImageCodecInfo iEncoder = ImageFormat.Jpeg.GetEncoder();

            if( iEncoder == null )
                Source.Save( Output, ImageFormat.Jpeg );
            else
            {
                EncoderParameters Params = new EncoderParameters( 1 );
                EncoderParameter QualityParam = new EncoderParameter( Encoder.Quality, (long)Quality );
                Params.Param[0] = QualityParam;

                Source.Save( Output, iEncoder, Params );
            }
        }

        /// <summary>
        /// Sets the Graphics object to prouce maximum quality images.
        /// </summary>
        /// <param name="Gfx">The Graphics object to alter.</param>
        private static void SetMaxQuality( this Graphics Gfx )
        {
            Gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Gfx.SmoothingMode = SmoothingMode.HighQuality;
            Gfx.CompositingQuality = CompositingQuality.HighQuality;
        }
    }
}