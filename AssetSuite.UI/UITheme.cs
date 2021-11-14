using System.Drawing;

namespace AssetSuite.UI
{
    public class UITheme
    {
        public Color BackColor { get; set; }
        
        public Color BorderColor { get; set; }
        
        public Color HoverColor { get; set; }
        
        public Color ActiveColor { get; set; }
        
        public Color TextColor { get; set; }

        public string Font { get; set; }

        public uint FontSize { get; set; }
        
        public bool ExecuteOnRelease { get; set; }

        public UITheme()
        {
            BackColor = Color.Gray;
            BorderColor = Color.Black;
            HoverColor = Color.LightSlateGray;
            ActiveColor = Color.DimGray;
            TextColor = Color.Black;
            Font = "Arial";
            FontSize = 12;
            ExecuteOnRelease = true;
        }
    }
}