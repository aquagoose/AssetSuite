using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssetSuite.UI
{
    public class Position
    {
        public Point ScreenPosition { get; private set; }

        public Vector2 VScreenPosition => ScreenPosition.ToVector2();

        public int X => ScreenPosition.X;

        public int Y => ScreenPosition.Y;

        public Point Offset;
        public DockType DockType;

        public Position(DockType dockType, Point offset)
        {
            Offset = offset;
            DockType = dockType;
        }

        public Position(DockType dockType, Vector2 offset) : this(dockType, offset.ToPoint()) { }

        public Position(Point offset) : this(DockType.TopLeft, offset) { }

        public Position(Vector2 offset) : this(DockType.TopLeft, offset.ToPoint()) { }

        public Position(int x, int y) : this(DockType.TopLeft, new Point(x, y)) { }

        public Position(float x, float y) : this(DockType.TopLeft, new Point((int) x, (int) y)) { }

        internal void Update(GraphicsDevice gd)
        {
            Point viewPort = gd.Viewport.Bounds.Size;

            switch (DockType)
            {
                case DockType.TopLeft:
                    ScreenPosition = Point.Zero;
                    break;
                case DockType.TopRight:
                    ScreenPosition = new Point(viewPort.X, 0) + Offset;
                    break;
                case DockType.Center:
                    ScreenPosition = viewPort / new Point(2) + Offset;
                    break;
                case DockType.BottomLeft:
                    ScreenPosition = new Point(0, viewPort.Y) + Offset;
                    break;
                case DockType.BottomRight:
                    ScreenPosition = viewPort + Offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum DockType
    {
        TopLeft,
        TopRight,
        Center,
        BottomLeft,
        BottomRight
    }
}