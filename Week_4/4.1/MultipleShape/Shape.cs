using SplashKitSDK;

namespace MultipleShape
{
    public abstract class Shape
    {
        // Fields
        private Color _color;
        private float _x, _y;
        private bool _selected;

        // Constructor
        public Shape()
        {
            _color = Color.Chocolate;
            _x = 0.0f;
            _y = 0.0f;
            _selected = false;
        }

        public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
            _selected = false;
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

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // Methods
        public abstract void Draw();
        public abstract void DrawOutline();
        public abstract bool IsAt(Point2D pt);
    }
}