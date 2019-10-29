namespace Training7
{
    using System;

    public class Rectangle
    {
        private float witdh;
        private float height;
        public Rectangle(float width, float height, float xPosition, float yPosition)
        {
            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
                XPosition = xPosition;
                YPosition = yPosition;
            }
            else
            {
                throw new ArgumentException("Width and height must be greater than zero!");
            }
        }

        public float Width 
        { 
            get 
            {
                return witdh;
            }
            set 
            {
                if (value > 0)
                {
                    witdh = value;
                }
                else
                {
                    throw new ArgumentException("Width must be greater than zero!");
                }
            } 
        }
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("Height must be greater than zero!");
                }
            } 
        }

        /// <summary>
        /// Centre of rectangle. Represented as intersection of diagonals. 
        /// </summary>
        public float XPosition { get; set; }
        public float YPosition { get; set; }
    }
}