namespace System.Drawing
{
	public static class PointExtensions
	{
		public static Point RotatePoint( this Point PointToRotate, Point CentrePoint, double AngleInDegrees )
		{
			double Radians = AngleInDegrees * ( Math.PI / 180 );
			double Cos = Math.Cos( Radians ), Sin = Math.Sin( Radians );

			double NewX = Cos * ( PointToRotate.X - CentrePoint.X ) - Sin * ( PointToRotate.Y - CentrePoint.Y ) + CentrePoint.X;
			double NewY = Sin * ( PointToRotate.X - CentrePoint.X ) + Cos * ( PointToRotate.Y - CentrePoint.Y ) + CentrePoint.Y;

			return new Point( (int)NewX, (int)NewY );
		}
	}
}