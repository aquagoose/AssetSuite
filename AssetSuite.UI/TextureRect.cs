using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;

namespace AssetSuite.UI
{
    public class TextureRect
    {
        public Point Position { get; set; }
        
        public Size Size { get; set; }
        
        public Color Color { get; set; }
        
        public Vector2 Origin { get; set; }

        private Texture2D _texture;
        private GraphicsDevice _gd;

        public TextureRect(GraphicsDevice gd, Point position, Size size, Color color)
        {
            Position = position;
            Size = size;
            Color = color;

            _texture = new Texture2D(gd, 1, 1);
            Color[] pixel = new[] { Color.White };
            _texture.SetData(pixel);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, Position.ToVector2(), null, Color, 0, Origin, new Vector2(Size.Width, Size.Height),
                SpriteEffects.None, 0);
        }
    }
}