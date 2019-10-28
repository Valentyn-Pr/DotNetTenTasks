using System;
using System.Collections.Generic;
using System.Text;

namespace Training2
{
    public struct Rectangle : ISize, ICoordinates
    {
        public float Witdh { get;  }
        public float Height { get;  }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Rectangle(float witdh, float height, int x, int y)
        {
            if (witdh > 0 && height > 0)
            {
                XCoordinate = x;
                YCoordinate = y;
                Witdh = witdh;
                Height = height;
            }
            else
            {
                throw new InvalidArgumentException("heigth or width are invalid");
            }
        }

        public float Perimeter()
        {
            return (Witdh > 0 && Height > 0) ? 2 * (Witdh + Height) : throw new InvalidArgumentException("heigth or width are invalid");
        }
    }
}
