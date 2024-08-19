using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SplashKitSDK;

namespace MultipleShape
{
    public class MyLine : Shape
    {
        private float _endX, _endY;

        public MyLine() : this(Color.Red, 0.0f, 0.0f, 88, 88)
        {
        }

        public MyLine(Color color, float x, float y, float endX, float endY) : base(color)
        {
            X = x;
            Y = y;
            EndX = endX;
            EndY = endY;
        }

        public float EndX
        {
            get => _endX;
            set => _endX = value;
        }

        public float EndY
        {
            get => _endY;
            set => _endY = value;
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, EndX, EndY);

            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY));
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
            SplashKit.DrawCircle(Color.Black, EndX, EndY, 5);
        }
    }
}