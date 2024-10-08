using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SplashKitSDK;

namespace DrawingProgram
{
    public class MyCircle : Shape
    {
        private float _radius;

        public MyCircle() : this(Color.Blue, 0.0f, 0.0f, 129)
        {
        }

        public MyCircle(Color color, float x, float y, float radius) : base(color)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, _radius);

            if (Selected)
            {
                DrawOutline();
            }
        }

        public override bool IsAt(Point2D pt)
        {
            Circle c = SplashKit.CircleAt(X, Y, _radius);
            return SplashKit.PointInCircle(pt, c);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}