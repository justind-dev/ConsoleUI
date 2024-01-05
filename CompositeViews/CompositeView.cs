using ConsoleUI.Interfaces;

namespace ConsoleUI.CompositeViews
{
    public class CompositeView : ICompositeView
    {
        private readonly List<IUIElement> _elements = new List<IUIElement>();

        /// <summary>
        /// Add a UI element to the composite view.
        /// </summary>
        /// <param name="element">The UI element to add.</param>
        public void AddElement(IUIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "UI element cannot be null.");
            }

            _elements.Add(element);
        }

        /// <summary>
        /// Display all UI elements in the composite view.
        /// </summary>
        public void Display()
        {
            foreach (var element in _elements)
            {
                element.Display();
            }
        }
    }
}
