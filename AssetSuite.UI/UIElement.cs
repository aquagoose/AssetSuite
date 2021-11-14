using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace AssetSuite.UI
{
    public abstract class UIElement : IDisposable
    {
        public string Name { get; set; }
        
        protected GraphicsDevice GraphicsDevice { get; }
        
        public Position Position { get; set; }
        
        public Size Size { get; set; }
        
        public Color Color { get; set; }
        
        public float Rotation { get; set; }
        
        public Vector2 Origin { get; set; }

        public bool Visible { get; set; } = true;

        public bool Disabled { get; set; } = false;

        public bool Hovering { get; private set; } = false;

        public bool Focused { get; private set; } = false;

        public bool CaptureMouse { get; set; } = true;

        public UIElement(string name, GraphicsDevice gd, Position position, Size size, Color color)
        {
            Name = name;
            Position = position;
            Size = size;
            Color = color;
            GraphicsDevice = gd;
        }

        public virtual void Update(ref bool mouseHovering)
        {
            if (!Disabled)
            {
                if (Input.MousePosition.X >= Position.X && Input.MousePosition.X <= Position.X + Size.Width &&
                    Input.MousePosition.Y >= Position.Y && Input.MousePosition.Y <= Position.Y + Size.Height &&
                    !mouseHovering)
                {
                    Hovering = true;
                    if (CaptureMouse)
                        mouseHovering = true;

                    if (Input.MouseDown(MouseButton.Left))
                        Focused = true;
                }
                else
                {
                    Hovering = false;
                    if (Input.MouseDown(MouseButton.Left))
                        Focused = false;
                }
            }
            
            Position.Update(GraphicsDevice);
        }

        public abstract void Draw(SpriteBatch batch);
        
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}