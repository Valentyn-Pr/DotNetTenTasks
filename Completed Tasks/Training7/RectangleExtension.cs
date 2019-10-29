namespace Training7
{
    using System;
    public static class RectangleExtension
    {
        private static float biggerXPosition;
        private static float biggerYPosition;
        private static float smallerXPosition;
        private static float smallerYPosition;

        private static float newRectangleWidth = 0;
        private static float newRectangleHeight = 0;
        private static float newRectangleXPosition;
        private static float newRectangleYPosition;

        public static Rectangle GetRectangleCreatedByCrossingWithRectangle(this Rectangle rectangle, Rectangle crossedRectangle)
        {
            if (rectangle.XPosition >= crossedRectangle.XPosition)
            {
                biggerXPosition = rectangle.XPosition;
                smallerXPosition = crossedRectangle.XPosition;
            }
            else
            {
                biggerXPosition = crossedRectangle.XPosition;
                smallerXPosition = rectangle.XPosition;
            }

            if (rectangle.YPosition >= crossedRectangle.YPosition)
            {
                biggerYPosition = rectangle.YPosition;
                smallerYPosition = crossedRectangle.YPosition;
            }
            else
            {
                biggerYPosition = crossedRectangle.YPosition;
                smallerYPosition = rectangle.YPosition;
            }

            if ((biggerXPosition - smallerXPosition) < (rectangle.Width / 2 + crossedRectangle.Width / 2))
            {
                newRectangleWidth = ((rectangle.Width / 2 + crossedRectangle.Width / 2) - (biggerXPosition - smallerXPosition)) / 2;
            }
            else if (biggerXPosition == smallerXPosition)
            {
                newRectangleWidth = rectangle.Width >= crossedRectangle.Width ? rectangle.Width : crossedRectangle.Width;
            }

            if ((biggerYPosition - smallerYPosition) < (rectangle.Height / 2 + crossedRectangle.Height / 2))
            {
                newRectangleHeight = ((rectangle.Height / 2 + crossedRectangle.Height / 2) - ((biggerYPosition - smallerYPosition)) / 2);
            }
            else if(biggerYPosition == smallerYPosition)
            {
                newRectangleHeight = rectangle.Height >= crossedRectangle.Height ? rectangle.Height : crossedRectangle.Height;
            }

            if (newRectangleHeight != 0 && newRectangleWidth != 0)
            {
                newRectangleXPosition = smallerXPosition + (biggerXPosition - smallerXPosition) + newRectangleWidth / 2;

                newRectangleYPosition = smallerYPosition + (biggerYPosition - smallerYPosition) + newRectangleHeight / 2;

                return new Rectangle(newRectangleWidth, newRectangleHeight, newRectangleXPosition, newRectangleYPosition);
            }
            else
            {
                throw new ArgumentException("this rectangles does not crosses!");
            }
        }
    }
}
