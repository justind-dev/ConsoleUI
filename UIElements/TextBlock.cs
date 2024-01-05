using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class TextBlock : IUIElement
    {
        /// <summary>
        /// The text content of the TextBlock.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Constructor for TextBlock.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public TextBlock(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text), "Text cannot be null.");
        }

        /// <summary>
        /// Display the text content to the console.
        /// </summary>
        public void Display()
        {
            Console.WriteLine(Text);
        }
    }
}
