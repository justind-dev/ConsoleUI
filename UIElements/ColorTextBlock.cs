using System;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class ColorTextBlock : IUIElement
    {
        public string Text { get; }
        public ConsoleColor TextColor { get; }
        public ConsoleColor BackgroundColor { get; }

        /// <summary>
        /// Constructor for ColorTextBlock.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="textColor">The foreground color of the text.</param>
        /// <param name="backgroundColor">The background color of the text.</param>
        public ColorTextBlock(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text), "Text cannot be null.");
            TextColor = textColor;
            BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Display the colored text to the console and then reset console color.
        /// </summary>
        public void Display()
        {
            ConsoleColor originalTextColor = Console.ForegroundColor;
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = TextColor;
            Console.BackgroundColor = BackgroundColor;
            Console.WriteLine(Text);

            Console.ForegroundColor = originalTextColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}
