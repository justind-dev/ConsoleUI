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
        /// Initializes a new instance of the TableBlock class with specified headers and optional color settings.
        /// </summary>
        /// <param name="headers">Column headers for the table.</param>
        /// <param name="headerForegroundColor">Foreground color for the headers. Default is <see cref="ConsoleColor.White"/>.</param>
        /// <param name="headerBackgroundColor">Background color for the headers. Default is <see cref="ConsoleColor.Black"/>.</param>
        /// <param name="displayHeaders">Flag to indicate whether to display headers. Default is true.</param>
        /// <exception cref="ArgumentNullException">Thrown when headers is null.</exception>
        /// <example>
        /// This example shows how to create a TableBlock with headers and custom colors:
        /// <code>
        /// var table = new TableBlock(
        ///     new[] { "Header1", "Header2" },
        ///     ConsoleColor.Yellow,
        ///     ConsoleColor.DarkBlue
        /// );
        /// </code>
        /// </example>
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
        /// <exception cref="ArgumentNullException">Thrown when the row is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the row does not have the same number of elements as the headers.</exception>
        /// <example>
        /// This example shows how to add a row to a table with two headers:
        /// <code>
        /// var table = new TableBlock(new[] { "Header1", "Header2" });
        /// table.AddRow(new[] { "Row1 Col1", "Row1 Col2" });
        /// </code>
        /// </example>
        public void AddRow(string[] row)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row), "Row cannot be null.");
            }

            if (row.Length != _headers.Length)
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
