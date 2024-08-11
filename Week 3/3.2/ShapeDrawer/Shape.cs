using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        // Fields
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        // Constructor
        public Shape(int param)
        {
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
            _selected = false;
        }

        // Methods
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);

            if (_selected)
            {
                DrawOutline();
            }
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= _x) && (pt.X <= (_x + _width))
                && (pt.Y >= _y) && (pt.Y <= (_y + _height));
        }

        public void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 9, _y - 9, _width + 18, _height + 18);
        }

        // Properties
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}