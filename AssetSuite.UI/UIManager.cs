using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace AssetSuite.UI
{
    public static class UIManager
    {
        private static readonly Dictionary<string, UIElement> _elements;
        private static List<UIElement> _reversedUiElements;

        public static UITheme Theme { get; set; }

        static UIManager()
        {
            _elements = new Dictionary<string, UIElement>();
            _reversedUiElements = new List<UIElement>();
            Theme = new UITheme();
        }

        public static void Add(UIElement element)
        {
            _elements.Add(element.Name, element);
            ReverseElements();
        }

        public static void Remove(string name)
        {
            _elements.Remove(name);
            ReverseElements();
        }

        public static void Clear()
        {
            _elements.Clear();
            _reversedUiElements.Clear();
        }

        private static void ReverseElements()
        {
            _reversedUiElements = _elements.Values.ToList();
            _reversedUiElements.Reverse();
        }

        public static T GetElement<T>(string name) where T : UIElement
        {
            return (T) _elements[name];
        }

        public static void Update(SpriteBatch batch)
        {
            // Whether or not the mouse is hovering over an element.
            bool mouseHovering = false;
            
            // Update all our elements in reverse, as the elements updated first are drawn last, meaning they will be
            // on top of other elements. This means it can be used to work out if the mouse is hovering over an element.
            foreach (UIElement element in _reversedUiElements)
                element.Update(ref mouseHovering);
        }

        public static void Draw(SpriteBatch batch)
        {
            // Draw all the elements in the correct order, no reversing here.
            foreach (UIElement element in _elements.Values)
                element.Draw(batch);
        }
    }
}