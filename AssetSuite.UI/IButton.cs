using Microsoft.Xna.Framework;

namespace AssetSuite.UI
{
    public interface IButton
    {
        public Color BorderColor { get; set; }
        
        public Color HoverColor { get; set; }
        
        public Color ClickColor { get; set; }
        
        public bool ExecuteOnRelease { get; set; }
        
        
    }
}