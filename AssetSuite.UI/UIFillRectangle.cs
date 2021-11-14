using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Point = Microsoft.Xna.Framework.Point;
using Color = Microsoft.Xna.Framework.Color;

namespace AssetSuite.UI
{
    public class UIFillRectangle : UIElement
    {
        private TextureRect _rect;

        public new Color Color
        {
            get => _rect.Color;
            set => _rect.Color = value;
        }

        public UIFillRectangle(string name, GraphicsDevice gd, Position position, Size size, Color color, bool captureMouse = true) 
            : base(name, gd, position, size, color)
        {
            _rect = new TextureRect(gd, Point.Zero, Size, color);
            CaptureMouse = captureMouse;
        }

        public override void Update(ref bool mouseHovering)
        {
            base.Update(ref mouseHovering);

            Position.Update(GraphicsDevice);
            _rect.Position = Position.ScreenPosition;
        }

        public override void Draw(SpriteBatch batch)
        {
            _rect.Draw(batch);
        }
    }
}