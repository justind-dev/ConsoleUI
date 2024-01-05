using System;
using System.Collections.Generic;
using ConsoleUI.Interfaces;

namespace ConsoleUI.UIElements
{
    public class Menu : IUIElement
    {
        private readonly List<(string option, Action action)> _menuItems = new List<(string, Action)>();

        /// <summary>
        /// Add a menu item with an associated action.
        /// </summary>
        /// <param name="option">The text of the menu item.</param>
        /// <param name="action">The action to execute for this menu item.</param>
        public void AddMenuItem(string option, Action action)
        {
            if (string.IsNullOrWhiteSpace(option))
            {
                throw new ArgumentException("Menu option cannot be null or whitespace.", nameof(option));
            }

            _menuItems.Add((option, action));
        }

        /// <summary>
        /// Display the menu and handle user selection.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuItems[i].option}");
            }

            Console.Write("Select an option: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _menuItems.Count)
            {
                _menuItems[choice - 1].action();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }
}
