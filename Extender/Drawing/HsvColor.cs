namespace System.Drawing
{
    public struct HsvColor : IEquatable<HsvColor>, IEquatable<Color>
    {
        private double _h, _s, _v;

        public double H
        {
            get => this._h;
            set => this._h = HsvColor.NormalizeDegrees( value );
        }

        public double S
        {
            get => this._s;
            set
            {
                if( !( value >= 0.0 && value <= 1.0 ) )
                    throw new ArgumentOutOfRangeException( nameof( value ) );

                this._s = Math.Round( value, 2 );
            }
        }

        public double V
        {
            get => this._v;
            set
            {
                if( !( value >= 0.0 && value <= 1.0 ) )
                    throw new ArgumentOutOfRangeException( nameof( value ) );

                this._v = Math.Round( value, 2 );
            }
        }

        public HsvColor( double h, double s, double v )
        {
            this._h = this._s = this._v = 0;

            this.H = HsvColor.NormalizeDegrees( h );
            this.S = Math.Round( s, 2 );
            this.V = Math.Round( v, 2 );
        }

        public bool Equals( HsvColor other ) => this._h == other._h && this._s == other._s && this._v == other._v;

        public bool Equals( Color other ) => (Color)this == other;

        public override bool Equals( object other )
        {
            switch( other )
            {
                case HsvColor hsv: return this.Equals( hsv );
                case Color rgb: return this.Equals( rgb );
                default: return false;
            }
        }

        public override int GetHashCode() => ( (Color)this ).GetHashCode();

        public override string ToString() => $"HsvColor [H={this.H}, S={this.S}, V={this.V}]";

        public static bool operator ==( HsvColor a, HsvColor b ) => a.Equals( b );

        public static bool operator !=( HsvColor a, HsvColor b )  => !a.Equals( b );

        public static bool operator ==( HsvColor a, Color b ) => a.Equals( b );

        public static bool operator !=( HsvColor a, Color b ) => !a.Equals( b );

        public static bool operator ==( Color a, HsvColor b ) => b.Equals( a );

        public static bool operator !=( Color a, HsvColor b ) => !b.Equals( a );

        // Convert from RGB to HSV
        public static implicit operator HsvColor( Color rgb )
        {
            double r = rgb.R / 255d,
                   g = rgb.G / 255d,
                   b = rgb.B / 255d;

            double min = Math.Min( Math.Min( r, g ), b ),
                   max = Math.Max( Math.Max( r, g ), b ),
                   delta = max - min;

            double h, s, v = max;

            if( delta < 0.00001 )
                return new HsvColor( 0, 0, v );

            if( max > 0d )
                s = delta / max;
            else
                return new HsvColor( 0, 0, v );

            if( r >= max )
                h = ( g - b ) / delta;
            else if( g >= max )
                h = 2d + ( b - r ) / delta;
            else
                h = 4d + ( r - g ) / delta;

            h *= 60d;

            if( h < 0d )
                h += 360d;

            return new HsvColor( h, s, v );
        }

        // Convert from HSV to RGB
        public static implicit operator Color( HsvColor self )
        {
            if( self._s <= 0.0 )
            {
                var c = (byte)( self._v * 255 );
                return Color.FromArgb( 255, c, c, c );
            }

            double r, g, b;
            var hh = HsvColor.Clamp( self.H, 0.0, 360.0 ) / 60d;
            var i = (long)hh;
            var ff = hh - i;
            var p = self._v * ( 1.0 - self._s );
            var q = self._v * ( 1.0 - self._s * ff );
            var t = self._v * ( 1.0 - self._s * ( 1.0 - ff ) );

            switch( i )
            {
                case 0:
                    r = self._v;
                    g = t;
                    b = p;
                    break;

                case 1:
                    r = q;
                    g = self._v;
                    b = p;
                    break;

                case 2:
                    r = p;
                    g = self._v;
                    b = t;
                    break;

                case 3:
                    r = p;
                    g = q;
                    b = self._v;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = self._v;
                    break;

                default:
                    r = self._v;
                    g = p;
                    b = q;
                    break;
            }

            return Color.FromArgb( 255, (byte)( r * 255 ), (byte)( g * 255 ), (byte)( b * 255 ) );
        }

        private static double NormalizeDegrees( double deg )
        {
            deg %= 360d;
            return Math.Round( deg < 0 ? deg + 360d : deg, 2 );
        }

        private static double Clamp( double value, double min, double max ) => value > max ? max : ( value < min ? min : value );
    }
}
