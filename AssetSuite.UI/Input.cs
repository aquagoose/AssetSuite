using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AssetSuite.UI
{
    public static class Input
    {
        private static KeyboardState _keyboardState;
        private static MouseState _mouseState;

        private static KeyboardState _lastKeyboardState;
        private static MouseState _lastMouseState;

        public static event OnTextInput TextInput;

        public static bool KeyDown(Keys key) => _keyboardState.IsKeyDown(key);

        public static bool KeyPressed(Keys key) => _keyboardState.IsKeyDown(key) && !_lastKeyboardState.IsKeyDown(key);

        public static bool MouseDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return _mouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.Right:
                    return _mouseState.RightButton == ButtonState.Pressed;
                case MouseButton.Middle:
                    return _mouseState.MiddleButton == ButtonState.Pressed;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        public static bool MousePressed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return _mouseState.LeftButton == ButtonState.Pressed &&
                           _lastMouseState.LeftButton == ButtonState.Released;
                case MouseButton.Right:
                    return _mouseState.RightButton == ButtonState.Pressed &&
                           _lastMouseState.RightButton == ButtonState.Released;
                case MouseButton.Middle:
                    return _mouseState.MiddleButton == ButtonState.Pressed &&
                           _lastMouseState.MiddleButton == ButtonState.Released;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        public static Point MousePosition => _mouseState.Position;

        public static void Initialize(Game game)
        {
            game.Window.TextInput += WindowOnTextInput;
        }

        public static void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            _lastKeyboardState = _keyboardState;
            _lastMouseState = _mouseState;

            _keyboardState = keyboardState;
            _mouseState = mouseState;
        }

        private static void WindowOnTextInput(object sender, TextInputEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public delegate void OnTextInput(char character);
    }

    public enum MouseButton
    {
        Left,
        Right,
        Middle
    }
}