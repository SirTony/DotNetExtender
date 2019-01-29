namespace System
{
    public sealed class ConsoleStyle : IDisposable
    {
        private readonly bool _isForeground;
        private readonly ConsoleColor _original;

        public ConsoleColor Color { get; }

        private ConsoleStyle( ConsoleColor color, bool isForeground )
        {
            this._isForeground = isForeground;
            this._original = Console.ForegroundColor;
            this.Color = color;
            this.Enable();
        }

        public void Enable() => Console.ForegroundColor = this.Color;
        public void Disable() => Console.ForegroundColor = this._original;

        public static ConsoleStyle Foreground( ConsoleColor color ) => new ConsoleStyle( color, true );
        public static ConsoleStyle Background( ConsoleColor color ) => new ConsoleStyle( color, false );

        public static void Foreground( ConsoleColor color, Action action )
        {
            using( ConsoleStyle.Foreground( color ) )
                action();
        }

        public static void Background( ConsoleColor color, Action action )
        {
            using( ConsoleStyle.Background( color ) )
                action();
        }

        public void Dispose() => this.Disable();
    }
}
