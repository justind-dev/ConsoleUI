
namespace ConsoleUI.Interfaces
{
    /// <summary>
    /// Interface for composite views that can contain multiple UI elements.
    /// </summary>
    public interface ICompositeView : IUIElement
    {
        /// <summary>
        /// Add a UI element to the composite view.
        /// </summary>
        /// <param name="element">The UI element to add.</param>
        void AddElement(IUIElement element);
    }
}
