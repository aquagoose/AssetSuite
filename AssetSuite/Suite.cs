using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssetSuite
{
    public class Suite : Game
    {
        private GraphicsDeviceManager _manager;
        private SpriteBatch _batch;
        
        public Suite()
        {
            IsMouseVisible = true;
            Window.Title = "Asset Suite";
            
            _manager = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            _manager.PreferredBackBufferWidth = 1280;
            _manager.PreferredBackBufferHeight = 720;
            _manager.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            GraphicsDevice.Clear(Color.Black);
        }
    }
}