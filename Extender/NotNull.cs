namespace System
{
    public struct NotNull<T> where T : class
    {
        private T mValue;
        public T Value
        {
            get { return this.mValue; }
            set
            {
                if( value == null )
                    throw new ArgumentNullException( "value" );

                this.mValue = value;
            }
        }

        public NotNull( T value )
            : this()
        {
            this.Value = value;
        }

        public static implicit operator T( NotNull<T> instance )
        {
            return instance.Value;
        }

        public static implicit operator NotNull<T>( T value )
        {
            return new NotNull<T>( value );
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public static bool operator ==( NotNull<T> left, T right )
        {
            return right == null ? false : left.Equals( right );
        }

        public static bool operator !=( NotNull<T> left, T right )
        {
            return !( left == right );
        }

        public override bool Equals( object other )
        {
            if( other == null )
                return false;

            if( other is NotNull<T> )
                return this.Equals( (NotNull<T>)other );

            if( other is T )
                return this.Equals( (T)other );

            return false;
        }

        public bool Equals( NotNull<T> other )
        {
            return this.Value.Equals( other.Value );
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}