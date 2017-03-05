using System.Collections.Generic;

namespace System
{
    public struct NotNull<T> : IEquatable<T>, IEquatable<NotNull<T>>
        where T : class
    {
        private T _value;

        public T Value
        {
            get { return this._value; }
            set
            {
                if( value == null )
                    throw new ArgumentNullException( "value" );

                this._value = value;
            }
        }

        public NotNull( T value )
            : this()
        {
            this.Value = value;
        }

        public static implicit operator T( NotNull<T> instance ) => instance.Value;

        public static implicit operator NotNull<T>( T value ) => new NotNull<T>( value );

        public override string ToString() => this.Value.ToString();

        public static bool operator ==( NotNull<T> left, T right ) => EqualityComparer<T>.Default.Equals( left._value, right );

        public static bool operator !=( NotNull<T> left, T right ) => !( left == right );

        public static bool operator ==( NotNull<T> left, NotNull<T> right ) => EqualityComparer<T>.Default.Equals( left._value, right._value );

        public static bool operator !=( NotNull<T> left, NotNull<T> right ) => !( left == right );

        public override bool Equals( object other )
        {
            if( object.ReferenceEquals( null, other ) ) return false;
            return other is NotNull<T> && this.Equals( (NotNull<T>)other );
        }

        public bool Equals( T other ) => this == other;

        public bool Equals( NotNull<T> other ) => this == other;

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode( this._value );
    }
}