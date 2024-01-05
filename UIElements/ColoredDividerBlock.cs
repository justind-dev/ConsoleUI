using System;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class ColoredDividerBlock : IUIElement
    {
        private readonly char _dividerChar;
        private readonly ConsoleColor _foregroundColor;
        private readonly ConsoleColor _backgroundColor;
        private readonly int _height;
        private readonly int _width;

        /// <summary>
        /// Constructor for ColoredDividerBlock.
        /// </summary>
        /// <param name="dividerChar">The character to use for the divider line.</param>
        /// <param name="foregroundColor">The foreground color of the divider.</param>
        /// <param name="backgroundColor">The background color of the divider.</param>
        /// <param name="height">The height of the divider in console lines.</param>
        /// <param name="width">The width of the divider.</param>
        public ColoredDividerBlock(char dividerChar = ' ',
                                   ConsoleColor foregroundColor = ConsoleColor.White,
                                   ConsoleColor backgroundColor = ConsoleColor.Black,
                                   int height = 1,
                                   int width = 80)
        {
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0.");
            }

            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0.");
            }

            _dividerChar = dividerChar;
            _foregroundColor = foregroundColor;
            _backgroundColor = backgroundColor;
            _height = height;
            _width = width;
        }

        /// <summary>
        /// Display the colored divider line in the console.
        /// </summary>
        public void Display()
        {
            string dividerLine = new string(_dividerChar, _width);
            ConsoleColor originalTextColor = Console.ForegroundColor;
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = _foregroundColor;
            Console.BackgroundColor = _backgroundColor;

            for (int i = 0; i < _height; i++)
            {
                Console.WriteLine(dividerLine);
            }

            Console.ForegroundColor = originalTextColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}
