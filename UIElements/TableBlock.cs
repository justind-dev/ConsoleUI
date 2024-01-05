using System;
using System.Collections.Generic;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class TableBlock : IUIElement
    {
        private readonly List<string[]> _rows = new List<string[]>();
        private readonly string[] _headers;
        private readonly ConsoleColor _headerForegroundColor;
        private readonly ConsoleColor _headerBackgroundColor;
        private readonly bool _displayHeaders;

        /// <summary>
        /// Constructor for TableBlock.
        /// </summary>
        /// <param name="headers">Column headers for the table.</param>
        /// <param name="headerForegroundColor">Foreground color for the headers.</param>
        /// <param name="headerBackgroundColor">Background color for the headers.</param>
        /// <param name="displayHeaders">Flag to indicate whether to display headers.</param>
        public TableBlock(string[] headers,
                          ConsoleColor headerForegroundColor = ConsoleColor.White,
                          ConsoleColor headerBackgroundColor = ConsoleColor.Black,
                          bool displayHeaders = true)
        {
            _headers = headers ?? throw new ArgumentNullException(nameof(headers), "Headers cannot be null.");
            _headerForegroundColor = headerForegroundColor;
            _headerBackgroundColor = headerBackgroundColor;
            _displayHeaders = displayHeaders;
        }

        /// <summary>
        /// Add a row to the table.
        /// </summary>
        /// <param name="row">The row to add. Must match the number of headers.</param>
        public void AddRow(string[] row)
        {
            if (row == null || row.Length != _headers.Length)
            {
                throw new ArgumentException("Row must have the same number of elements as there are headers.", nameof(row));
            }

            _rows.Add(row);
        }

        /// <summary>
        /// Display the table to the console.
        /// </summary>
        public void Display()
        {
            if (_displayHeaders)
            {
                DisplayRow(_headers, _headerForegroundColor, _headerBackgroundColor);
            }
            foreach (var row in _rows)
            {
                DisplayRow(row, ConsoleColor.Gray, ConsoleColor.Black); // Default colors for rows
            }
        }

        private void DisplayRow(string[] row, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ConsoleColor originalTextColor = Console.ForegroundColor;
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(string.Join(" | ", row));

            Console.ForegroundColor = originalTextColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
    }
}
