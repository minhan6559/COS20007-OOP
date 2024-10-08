using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleShape
{
    public class MyRectangle : Shape
    {
        private float _width, _height;

        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 194, 194)
        {
        }

        public MyRectangle(Color color, float x, float y, float width, float height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        // Methods
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);

            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X) && (pt.X <= (X + _width))
                && (pt.Y >= Y) && (pt.Y <= (Y + _height));
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 9, Y - 9, Width + 18, Height + 18);
        }
    }
}