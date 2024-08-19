using System;
using MultipleShape;
using SplashKitSDK;

namespace MultipleShape
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();

            ShapeKind kindToAdd = ShapeKind.Circle;

            // My ID: 104844794 => Last digit: 4
            // So I'm only able to draw a maximum of X lines within the timeframe
            int maxLines = 4;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                // If the user presses the C key or has run out of lines to draw, they will draw circles
                if (SplashKit.KeyTyped(KeyCode.CKey) || maxLines <= 0)
                {
                    kindToAdd = ShapeKind.Circle;
                }

                // If the user presses the L key and has lines left to draw, they will draw lines
                if (SplashKit.KeyTyped(KeyCode.LKey) && maxLines > 0)
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Circle:
                            myShape = new MyCircle();
                            break;
                        case ShapeKind.Line:
                            myShape = new MyLine();
                            maxLines--;
                            break;
                        default:
                            myShape = new MyRectangle();
                            break;
                    }

                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(myShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = new Point2D();
                    pt.X = SplashKit.MouseX();
                    pt.Y = SplashKit.MouseY();

                    myDrawing.SelectShapesAt(pt);
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.RemoveSelectedShapes();
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
