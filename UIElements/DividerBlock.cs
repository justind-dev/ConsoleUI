using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class DividerBlock : IUIElement
    {
        private readonly int _numberOfLines;

        /// <summary>
        /// Constructor for DividerBlock.
        /// </summary>
        /// <param name="numberOfLines">The number of blank lines to insert as a divider.</param>
        public DividerBlock(int numberOfLines)
        {
            if (numberOfLines < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfLines), "Number of lines cannot be negative.");
            }

            _numberOfLines = numberOfLines;
        }

        /// <summary>
        /// Display the divider (blank lines) in the console.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < _numberOfLines; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
